using CargosService.DataAccess.Contract.Models;

namespace CargosService.DataAccess.Contract.Infrastructure
{
    public interface IUnitOfWork
    {
        void Save();

        IRepository<TData> Repository<TData>() where TData : EntityRoot;
    }
}
