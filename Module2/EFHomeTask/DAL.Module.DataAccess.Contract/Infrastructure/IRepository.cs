using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.DataAccess.Contract.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : EntityRoot
    {
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
