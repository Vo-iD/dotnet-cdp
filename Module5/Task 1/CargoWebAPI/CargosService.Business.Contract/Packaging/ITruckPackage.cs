using System.Collections.Generic;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface ITruckPackage
    {
        IList<Cargo> Cargos { get; }
        IList<string> Warnings { get; } 
    }
}
