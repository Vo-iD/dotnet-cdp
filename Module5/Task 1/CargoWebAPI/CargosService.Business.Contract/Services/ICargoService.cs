using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Services
{
    public interface ICargoService : IRepository<Cargo>
    {
    }
}