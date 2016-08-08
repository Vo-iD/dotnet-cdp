using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using CargosService.Business.Contract.Services;
using CargosService.DataAccess.Contract.Cache;
using CargosService.DataAccess.Contract.Exceptions;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Services
{
    public class CargoCacheService : ICargoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICargoCacheStorage _cacheStorage;
        private readonly TimeSpan _expirationTime;
        private readonly TimeSpan _blackZoneTime;
        private readonly TimeSpan _updateDelay;

        public CargoCacheService(IUnitOfWork untOfWork, ICargoCacheStorage cacheStorage)
        {
            _unitOfWork = untOfWork;
            _cacheStorage = cacheStorage;
            _expirationTime = new TimeSpan(0, 0, int.Parse(ConfigurationManager.AppSettings["CacheExpirationTime"]));
            _blackZoneTime = new TimeSpan(0, 0, int.Parse(ConfigurationManager.AppSettings["CacheBlackZoneTime"]));
            _updateDelay = new TimeSpan(0, 0, int.Parse(ConfigurationManager.AppSettings["CacheUpdateStorageDelay"]));
        }

        public Cargo Get(Guid id)
        {
            var entityFromCache = _cacheStorage.Get(id);
            if (entityFromCache != null)
            {
                if (DateTime.UtcNow > entityFromCache.LastUpdateUtc.Add(_blackZoneTime)
                    && DateTime.UtcNow < entityFromCache.LastUpdateUtc.Add(_expirationTime))
                {
                    Task.Run(() => UpdateCache(id));
                    return entityFromCache.Entity;
                }

                if (DateTime.UtcNow < entityFromCache.LastUpdateUtc.Add(_blackZoneTime))
                {
                    return entityFromCache.Entity;
                }

                if (DateTime.UtcNow > entityFromCache.LastUpdateUtc.Add(_expirationTime))
                {
                    return UpdateCache(id).Result;
                }
            }

            return InsertToCahce(id);
        }

        public void Insert(Cargo entity)
        {
            _cacheStorage.InsertOrUpdate(entity);
            RunSync();
        }

        public void Update(Cargo entity)
        {
            _cacheStorage.InsertOrUpdate(entity);
            RunSync();
        }

        public void Delete(Guid id)
        {
            _cacheStorage.Delete(id);
            try
            {
                _unitOfWork.Repository<Cargo>().Delete(id);
            }
            catch (EntityNotFoundException)
            {
            }
        }

        private Cargo InsertToCahce(Guid id)
        {
            var entity = _unitOfWork.Repository<Cargo>().Get(id);
            if (entity != null)
            {
                _cacheStorage.InsertOrUpdate(entity);
            }

            return entity;
        }

        private async Task<Cargo> UpdateCache(Guid id)
        {
            var entity = _unitOfWork.Repository<Cargo>().Get(id);
            if (entity != null)
            {
                var cache = _cacheStorage.Get(id);
                cache.Entity = entity;
            }
            else
            {
                _cacheStorage.Delete(id);
            }

            return entity;
        }

        private void RunSync()
        {
            if (_cacheStorage.SyncScheduled)
            {
                return;
            }

            _cacheStorage.SyncScheduled = true;
            Task.Run(() => Sync());
        }

        private async void Sync()
        {
            await Task.Delay(_updateDelay);
            _cacheStorage.SyncInProgress = true;

            var pendingInsert = _cacheStorage.GetPendingInsert().ToList();
            var pendingUpdate = _cacheStorage.GetPendingUpdate().ToList();

            foreach (var cacheEntity in pendingInsert)
            {
                _unitOfWork.Repository<Cargo>().Insert(cacheEntity);
            }

            foreach (var cacheEntity in pendingUpdate)
            {
                _unitOfWork.Repository<Cargo>().Update(cacheEntity);
            }

            _unitOfWork.Save();

            _cacheStorage.ResetPendingActions(pendingInsert.ToList());
            _cacheStorage.ResetPendingActions(pendingUpdate.ToList());

            _cacheStorage.SyncScheduled = false;
            _cacheStorage.SyncInProgress = false;
        }
    }
}
