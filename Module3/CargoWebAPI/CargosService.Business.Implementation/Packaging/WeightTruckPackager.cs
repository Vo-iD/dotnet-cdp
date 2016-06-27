using System;
using CargosService.Business.Contract.Packaging;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class WeightTruckPackager : ITruckPackager
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeightTruckPackager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ITruckPackage PackTruck(Truck truck)
        {
            throw new NotImplementedException();
        }
    }
}
