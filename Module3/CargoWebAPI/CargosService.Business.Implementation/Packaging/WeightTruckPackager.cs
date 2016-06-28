using System;
using CargosService.Business.Contract.Packaging;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class WeightTruckPackager : ITruckPackager
    {
        private readonly IPackagingManager _manager;

        public WeightTruckPackager(IPackagingManager manager)
        {
            _manager = manager;
        }

        public ITruckPackage PackTruck(Truck truck)
        {
            throw new NotImplementedException();
        }
    }
}
