using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface ITruckPackager
    {
        ITruckPackage PackTruck(Truck truck);
    }
}
