using CargosService.Business.Contract.Packaging;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class PackagingService : IPackagingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPackagingConfiguration _configuration;

        public PackagingService(IUnitOfWork unitOfWork, IPackagingConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public ITruckPackage LoadTruck(Truck truck)
        {
            var packager = GetPackager(_configuration.Strategy);

            return packager.PackTruck(truck);
        }

        private ITruckPackager GetPackager(OptimizationStrategy strategy) // todo maybe refactor by some way? It can be configured by IoC...
        {
            switch (strategy)
            {
                case OptimizationStrategy.Volume:
                {
                    return new VolumeTruckPackager(_unitOfWork);
                }
                case OptimizationStrategy.Weight:
                {
                    return new WeightTruckPackager(_unitOfWork);
                }
            }

            return null;
        }
    }
}
