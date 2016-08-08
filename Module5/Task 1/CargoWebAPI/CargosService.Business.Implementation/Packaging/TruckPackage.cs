using System.Collections.Generic;
using CargosService.Business.Contract.Packaging;

namespace CargosService.Business.Implementation.Packaging
{
    public class TruckPackage : ITruckPackage
    {
        public TruckPackage()
        {
            Cargos = new List<DataAccess.Contract.Models.Cargo>();
            Warnings = new List<string>();
        }

        public IList<DataAccess.Contract.Models.Cargo> Cargos { get; private set; }
        public IList<string> Warnings { get; private set; } 
    }
}
