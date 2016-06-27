using System;
using System.Configuration;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;

namespace CargosService.Configuration.Implementation.Settings
{
    public class PackagingConfiguration : ConfigurationSection, IPackagingConfiguration
    {
        private const string StrategyNodeName = "Strategy";

        private static ConfigurationProperty _strategy;

        public PackagingConfiguration()
        {
            _strategy = new ConfigurationProperty(StrategyNodeName, typeof (string),
                null, ConfigurationPropertyOptions.IsRequired); // todo try to refactor with default value
        }

        [ConfigurationProperty(StrategyNodeName, IsRequired = true)]
        public OptimizationStrategy Strategy
        {
            get { return (OptimizationStrategy) Enum.Parse(typeof (OptimizationStrategy), base[_strategy].ToString()); }
        }
    }
}
