using System.Collections.Generic;
using System.Linq;
using CargosService.Business.Contract.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public abstract class TruckPackager : ITruckPackager
    {
        protected const string PrioritiseWarning = "Prioritised cargos still exist at store";
        protected const string ToLowFillingWarning = "Truck filling is low. Expected >= {0}, but now = {1}";

        protected readonly IPackagingManager Manager;
        protected readonly IPackagingConfiguration Configuration;

        protected TruckPackager(IPackagingManager manager, IPackagingConfiguration configuration)
        {
            Manager = manager;
            Configuration = configuration;
        }

        public abstract ITruckPackage PackTruck(Truck truck);

        protected void PackWithPrioritised(Truck truck, ITruckPackage pack, ref double totalVolume, ref double totalWeight)
        {
            var prioritisedCargos = GetOrderedEnumeration(Manager.GetPrioritisedCargos(truck.Volume, truck.Payload));
            EnumerateCargos(prioritisedCargos, truck, pack, ref totalVolume, ref totalWeight);

            if (prioritisedCargos.Count() > pack.Cargos.Count)
            {
                pack.Warnings.Add(PrioritiseWarning);
            }
        }

        protected void PackWithNonPrioritised(Truck truck, ITruckPackage pack, ref double totalVolume, ref double totalWeight)
        {
            var nonPrioritisedCargos = Manager.GetNonPrioritisedCargos(truck.Volume, truck.Payload).OrderBy(x => x.Weight);
            EnumerateCargos(nonPrioritisedCargos, truck, pack, ref totalVolume, ref totalWeight);
        }

        protected abstract void EnumerateCargos(IEnumerable<Cargo> cargoes, Truck truck, ITruckPackage pack,
            ref double totalVolume, ref double totalWeight);

        protected abstract IEnumerable<Cargo> GetOrderedEnumeration(IQueryable<Cargo> cargoes);
    }
}
