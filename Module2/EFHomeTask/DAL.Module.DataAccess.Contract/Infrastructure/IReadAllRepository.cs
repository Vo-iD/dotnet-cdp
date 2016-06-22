using System.Linq;
using DAL.Module.DataAccess.Contract.Models;

namespace DAL.Module.DataAccess.Contract.Infrastructure
{
    public interface IReadAllRepository<TEntity> where TEntity : EntityRoot
    {
        IQueryable<TEntity> Get();
    }
}
