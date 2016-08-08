using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CargosService.DataAccess.Contract.Cache;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Implementation.Cache
{
    public class CargoCacheStorage : ICargoCacheStorage
    {
        private ConcurrentDictionary<Guid, CacheEntity<Cargo>> _cargoes;
 
        public CargoCacheStorage()
        {
            _cargoes = new ConcurrentDictionary<Guid, CacheEntity<Cargo>>();
        }

        public bool SyncScheduled { get; set; }

        public bool SyncInProgress { get; set; }

        public CacheEntity<Cargo> Get(Guid id)
        {
            try
            {
                return _cargoes[id];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void InsertOrUpdate(Cargo entity)
        {
            var cacheEntity = Get(entity.Id);
            if (cacheEntity == null)
            {
                var cargo = new CacheEntity<Cargo>(entity)
                {
                    PendingAction = PendingAction.Insert
                };

                _cargoes.TryAdd(entity.Id, cargo);
            }
            else
            {
                cacheEntity.Entity = entity;
                cacheEntity.PendingAction = PendingAction.Update;
            }
        }

        public void Delete(Guid id)
        {
            CacheEntity<Cargo> cacheEntity;
            _cargoes.TryRemove(id, out cacheEntity);
        }

        public IEnumerable<Cargo> GetPendingInsert()
        {
            return _cargoes.ToList()
                .Where(c => c.Value.PendingAction == PendingAction.Insert)
                .Select(x => x.Value.Entity);
        }

        public IEnumerable<Cargo> GetPendingUpdate()
        {
            return _cargoes.ToList()
                .Where(c => c.Value.PendingAction == PendingAction.Update)
                .Select(x => x.Value.Entity);
        }

        public void ResetPendingActions(IList<Cargo> cargoes)
        {
            foreach (var cargo in cargoes.ToList())
            {
                var pendingCargo = Get(cargo.Id);
                if (pendingCargo != null)
                {
                    pendingCargo.PendingAction = PendingAction.None;
                }
            }
        }
    }
}
