using System.Collections.Generic;
using CargosService.Business.Contract.Packaging;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Implementation.Packaging
{
    public class TruckPackage : ITruckPackage
    {
        public TruckPackage()
        {
            Cargos = new List<Cargo>();
            Warnings = new List<string>();
        }

        public IEnumerable<Cargo> Cargos { get; private set; }
        public IEnumerable<string> Warnings { get; private set; } 
    }
}
