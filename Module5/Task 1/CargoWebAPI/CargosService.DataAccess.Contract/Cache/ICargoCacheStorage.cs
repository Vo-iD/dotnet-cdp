using System;
using System.Collections.Generic;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Cache
{
    public interface ICargoCacheStorage
    {
        CacheEntity<Cargo> Get(Guid id);
        void InsertOrUpdate(Cargo entity);
        void Delete(Guid id);
        IEnumerable<Cargo> GetPendingInsert();
        IEnumerable<Cargo> GetPendingUpdate();
        void ResetPendingActions(IList<Cargo> cargoes);
        bool SyncScheduled { get; set; }
        bool SyncInProgress { get; set; }
    }
}
