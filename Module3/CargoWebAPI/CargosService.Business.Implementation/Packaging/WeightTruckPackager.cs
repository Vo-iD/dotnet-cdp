﻿using System.Collections.Generic;
using System.Linq;
using CargosService.Business.Contract.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class WeightTruckPackager : TruckPackager
    {
        public WeightTruckPackager(IPackagingManager manager, IPackagingConfiguration configuration)
            : base(manager, configuration)
        {
        }

        public override ITruckPackage PackTruck(Truck truck)
        {
            var pack = new TruckPackage();

            var totalVolume = 0.0;
            var totalWeight = 0.0;

            PackWithPrioritised(truck, pack, ref totalVolume, ref totalWeight);
            if (totalWeight < truck.Payload)
            {
                PackWithNonPrioritised(truck, pack, ref totalVolume, ref totalWeight);
            }

            var fillingThreshold = (double) Configuration.FillThreshold / 100 * truck.Payload;
            if (totalWeight < fillingThreshold)
            {
                pack.Warnings.Add(string.Format(ToLowFillingWarning, fillingThreshold, totalVolume));
            }

            return pack;
        }

        protected override void EnumerateCargos(IEnumerable<Cargo> cargoes, Truck truck, ITruckPackage pack,
            ref double totalVolume, ref double totalWeight)
        {
            foreach (var cargo in cargoes)
            {
                if (totalWeight + cargo.Weight > truck.Payload)
                {
                    break;
                }

                if (totalVolume + cargo.Volume <= truck.Volume)
                {
                    totalVolume += cargo.Volume;
                    totalWeight += cargo.Weight;

                    pack.Cargos.Add(cargo);
                }
            }
        }

        protected override IEnumerable<Cargo> GetOrderedEnumeration(IQueryable<Cargo> cargoes)
        {
            return cargoes.OrderBy(c => c.Weight);
        }
    }
}
