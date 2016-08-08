using System;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Cache
{
    public class CacheEntity<TEntity> where TEntity : EntityRoot
    {
        private TEntity _entity;

        public CacheEntity(TEntity entity)
        {
            LastReadUtc = DateTime.UtcNow;
            LastUpdateUtc = DateTime.UtcNow;
            ReadCount = 0;
            Entity = entity;
        }

        public DateTime LastReadUtc { get; private set; }

        public DateTime LastUpdateUtc { get; private set; }

        public TEntity Entity
        {
            get
            {
                ReadCount++;
                RefreshLastRead();
                return _entity;
            }
            set
            {
                RefreshLastUpdate();
                _entity = value;
            }
        }

        public int ReadCount { get; private set; }

        public PendingAction PendingAction { get; set; }

        private void RefreshLastRead()
        {
            LastReadUtc = DateTime.UtcNow;
        }

        private void RefreshLastUpdate()
        {
            LastUpdateUtc = DateTime.UtcNow;
        }
    }
}
