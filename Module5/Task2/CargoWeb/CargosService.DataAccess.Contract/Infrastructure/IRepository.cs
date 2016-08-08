using System;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : EntityRoot
    {
        TEntity Get(Guid id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
