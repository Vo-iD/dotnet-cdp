using System;
using System.Linq;
using CargosService.Business.Contract.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class PackagingManager : IPackagingManager
    {
        private readonly IFullRepository<Cargo> _cargoRepository;
        private readonly IPackagingConfiguration _configuration;
 
        public PackagingManager(IFullRepository<Cargo> cargoRepository, IPackagingConfiguration configuration)
        {
            _cargoRepository = cargoRepository;
            _configuration = configuration;
        }

        public IQueryable<Cargo> GetPrioritisedCargos(double maxVolume, int maxWeight)
        {
            var cargos = GetAvailableCargos(maxVolume, maxWeight);
            return cargos.Where(x => x.RegisterDate <= DateTime.UtcNow.AddDays(-_configuration.HighPriorityDayThreshold));
        }

        public IQueryable<Cargo> GetNonPrioritisedCargos(double maxVolume, int maxWeight)
        {
            var cargos = GetAvailableCargos(maxVolume, maxWeight);
            return cargos.Where(x => x.RegisterDate > DateTime.UtcNow.AddDays(-_configuration.HighPriorityDayThreshold));
        }

        private IQueryable<Cargo> GetAvailableCargos(double maxVolume, int maxWeight)
        {
            return _cargoRepository.Get().Where(c => c.Volume < maxVolume && c.Weight < maxWeight);
        }
    }
}
