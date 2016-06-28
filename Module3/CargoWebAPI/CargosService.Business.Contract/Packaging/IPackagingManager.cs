using System.Linq;
using CargosService.DataAccess.Contract.Models;

namespace CargosService.Business.Contract.Packaging
{
    public interface IPackagingManager
    {
        IQueryable<Cargo> GetPrioritisedCargos(double maxVolume, int maxWeight);
        IQueryable<Cargo> GetNonPrioritisedCargos(double maxVolume, int maxWeight);
    }
}
