using System.Collections.Generic;
using System.Linq;
using CargosService.Business.Contract.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class VolumeTruckPackager : ITruckPackager
    {
        private readonly IPackagingManager _manager;
        private readonly IPackagingConfiguration _configuration;
        private const string PrioritiseWarning = "Prioritised cargos still exist at store";
        private const string ToLowFillingWarning = "Truck filling is low. Expected >= {0}, but now = {1}";

        public VolumeTruckPackager(IPackagingManager manager, IPackagingConfiguration configuration)
        {
            _manager = manager;
            _configuration = configuration;
        }

        public ITruckPackage PackTruck(Truck truck)
        {
            var pack = new TruckPackage();

            var totalVolume = 0.0;
            var totalWeight = 0.0;

            PackWithPrioritised(truck, pack, ref totalVolume, ref totalWeight);
            if (totalVolume < truck.Volume)
            {
                PackWithNonPrioritised(truck, pack, ref totalVolume, ref totalWeight);
            }

            var fillingThreshold = (double) _configuration.FillThreshold/100*truck.Volume;
            if (totalVolume < fillingThreshold)
            {
                pack.Warnings.Add(string.Format(ToLowFillingWarning, fillingThreshold, totalVolume));
            }

            return pack;
        }

        private void PackWithPrioritised(Truck truck, ITruckPackage pack, ref double totalVolume, ref double totalWeight)
        {
            var prioritisedCargos = _manager.GetPrioritisedCargos(truck.Volume, truck.Payload).OrderBy(x => x.Volume);
            EnumerateCargos(prioritisedCargos, truck, pack, ref totalVolume, ref totalWeight);

            if (prioritisedCargos.Count() > pack.Cargos.Count)
            {
                pack.Warnings.Add(PrioritiseWarning);
            }
        }

        private void PackWithNonPrioritised(Truck truck, ITruckPackage pack, ref double totalVolume, ref double totalWeight)
        {
            var nonPrioritisedCargos = _manager.GetNonPrioritisedCargos(truck.Volume, truck.Payload).OrderBy(x => x.Volume);
            EnumerateCargos(nonPrioritisedCargos, truck, pack, ref totalVolume, ref totalWeight);
        }

        private void EnumerateCargos(IEnumerable<Cargo> cargoes, Truck truck, ITruckPackage pack, ref double totalVolume, ref double totalWeight)
        {
            foreach (var cargo in cargoes)
            {
                if (totalVolume + cargo.Volume > truck.Volume)
                {
                    break;
                }

                if (totalWeight + cargo.Weight <= truck.Payload)
                {
                    totalVolume += cargo.Volume;
                    totalWeight += cargo.Weight;

                    pack.Cargos.Add(cargo);
                }
            }
        }
    }
}
