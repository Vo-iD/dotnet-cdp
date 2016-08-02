using System;

namespace CargosService.Business.Contract.Cache
{
    public class CachePackage<TEntity> where TEntity: class 
    {
        public CachePackage(TEntity entity)
        {
            Payload = entity;
            LastReadFromStore = DateTime.UtcNow;
        }

        public TEntity Payload { get; set; }

        public DateTime LastReadFromStore { get; set; }
    }
}
