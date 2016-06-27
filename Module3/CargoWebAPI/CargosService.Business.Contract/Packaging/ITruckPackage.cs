using System.Collections.Generic;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface ITruckPackage
    {
        IEnumerable<Cargo> Cargos { get; }
        IEnumerable<string> Warnings { get; } 
    }
}
