using System.Linq;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Infrastructure
{
    public interface IFullRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityRoot
    {
        IQueryable<TEntity> Get();
    }
}
