using System.Linq;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Infrastructure
{
    public interface IReadAllRepository<TEntity> where TEntity : EntityRoot
    {
        IQueryable<TEntity> Get();
    }
}
