using System.Linq;
using DataAccess.Contract.Models;

namespace DataAccess.Contract.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : EntityRoot
    {
        IQueryable<TEntity> Get();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Save();
    }
}
