using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface IPackagingService
    {
        ITruckPackage LoadTruck(Truck truck);
    }
}
