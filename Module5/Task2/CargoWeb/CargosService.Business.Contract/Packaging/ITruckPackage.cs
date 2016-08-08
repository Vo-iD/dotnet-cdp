using System.Collections.Generic;

namespace CargosService.Business.Contract.Packaging
{
    public interface ITruckPackage
    {
        IList<DataAccess.Contract.Models.Cargo> Cargos { get; }
        IList<string> Warnings { get; } 
    }
}
