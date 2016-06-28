using CargosService.Business.Contract.Packaging;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class PackagingService : IPackagingService
    {
        private readonly IPackagingManager _manager;
        private readonly IPackagingConfiguration _configuration;

        public PackagingService(IPackagingManager manager, IPackagingConfiguration configuration)
        {
            _manager = manager;
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
                    return new VolumeTruckPackager(_manager, _configuration);
                }
                case OptimizationStrategy.Weight:
                {
                    return new WeightTruckPackager(_manager);
                }
            }

            return null;
        }
    }
}
