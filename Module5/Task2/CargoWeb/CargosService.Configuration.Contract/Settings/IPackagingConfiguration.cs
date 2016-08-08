using CargosService.Common.Contracts;

namespace CargosService.Configuration.Contract.Settings
{
    public interface IPackagingConfiguration
    {
        OptimizationStrategy Strategy { get; }

        int FillThreshold { get; }

        int HighPriorityDayThreshold { get; }
    }
}
