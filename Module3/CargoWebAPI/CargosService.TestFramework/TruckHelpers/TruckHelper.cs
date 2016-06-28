using CargosService.DataAccess.Contract.Models;

namespace CargosService.TestFramework.TruckHelpers
{
    public static class TruckHelper
    {
        public static Truck GetTestTruck()
        {
            return new Truck
            {
                Id = 1,
                Volume = 100,
                Payload = 18500,
                Brand = "MAN",
                Year = 2010,
                RegistrationNumber = "1ABC234",
                FuelConsumption = 22
            };
        }
    }
}
