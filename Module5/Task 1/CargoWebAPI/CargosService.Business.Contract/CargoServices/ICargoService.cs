using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.CargoServices
{
    public interface ICargoService
    {
        Cargo Get(int id);
        int Insert(Cargo cargo);
        int Update(Cargo cargo);
        int Delete(int id);
    }
}
