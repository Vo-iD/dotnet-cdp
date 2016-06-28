using System;
using System.Collections.Generic;
using System.Linq;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.TestFramework.CargoHelpers
{
    public static class CargoHelper
    {
        public static IQueryable<Cargo> GetFullCargoList()
        {
            var cargoList = new List<Cargo>();
            FillCargoList(cargoList);

            return new EnumerableQuery<Cargo>(cargoList);
        }

        public static IQueryable<Cargo> GetBigVolumeList()
        {
            var cargo = GetTestCargo();
            cargo.Volume = 49;

            var cargoList = new List<Cargo>
            {
                cargo, cargo, cargo, cargo, cargo
            };

            return new EnumerableQuery<Cargo>(cargoList);
        } 

        public static IQueryable<Cargo> GetBigWeightList()
        {
            var cargo = GetTestCargo();
            cargo.Weight = 10000;

            var cargoList = new List<Cargo>
            {
                cargo, cargo, cargo, cargo, cargo
            };

            return new EnumerableQuery<Cargo>(cargoList);
        } 

        public static IQueryable<Cargo> GetPrioritisedCargoes()
        {
            var cargoList = new List<Cargo>();

            var cargoWithHighPriority = GetTestCargo();
            cargoWithHighPriority.RegisterDate = DateTime.UtcNow.AddDays(-3);

            cargoList.Add(cargoWithHighPriority);
            cargoList.Add(cargoWithHighPriority);

            return new EnumerableQuery<Cargo>(cargoList);
        }

        public static IQueryable<Cargo> GetNonPrioritisedCargoes()
        {
            var cargoList = new List<Cargo>
            {
                GetTestCargo(),
                GetTestCargo(),
                GetTestCargo()
            };

            return new EnumerableQuery<Cargo>(cargoList);
        }

        public static Cargo GetTestCargo()
        {
            return new Cargo
            {
                Id = 1,
                Volume = 2,
                Weight = 23,
                RegisterDate = DateTime.UtcNow.AddDays(-1),
                Price = 120
            };
        }

        public static void FillCargoList(List<Cargo> cargoList)
        {
            cargoList.AddRange(GetPrioritisedCargoes());
            cargoList.AddRange(GetNonPrioritisedCargoes());

            var cargoWithHighPriority = GetTestCargo();
            cargoWithHighPriority.RegisterDate = DateTime.UtcNow.AddDays(-3);
            cargoWithHighPriority.Volume = 1500;

            cargoList.Add(cargoWithHighPriority);
        }
    }
}
