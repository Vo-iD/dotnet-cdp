using System.Linq;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface IPackagingManager
    {
        IQueryable<DataAccess.Contract.Models.Cargo> GetPrioritisedCargos(double maxVolume, int maxWeight);
        IQueryable<DataAccess.Contract.Models.Cargo> GetNonPrioritisedCargos(double maxVolume, int maxWeight);
    }
}
