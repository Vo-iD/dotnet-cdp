using System.Configuration;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;

namespace CargosService.Configuration.Implementation.Settings
{
    public class PackagingConfiguration : ConfigurationSection, IPackagingConfiguration
    {
        private const string StrategyNodeName = "Strategy";
        private const string FillThresholdNodeName = "FillThreshold";
        private const string HighPriorityDayThresholdNodeName = "HighPriorityDayThreshold";

        private static ConfigurationProperty _strategy;
        private static ConfigurationProperty _fillThreshold;
        private static ConfigurationProperty _highPriorityDayThreshold;

        public PackagingConfiguration()
        {
            _strategy = new ConfigurationProperty(StrategyNodeName, typeof (string),
                null, ConfigurationPropertyOptions.IsRequired); // todo try to refactor with default value
            _fillThreshold = new ConfigurationProperty(FillThresholdNodeName, typeof(string),
                null, ConfigurationPropertyOptions.IsRequired);
            _highPriorityDayThreshold = new ConfigurationProperty(HighPriorityDayThresholdNodeName, typeof(string),
                null, ConfigurationPropertyOptions.IsRequired); 
        }

        [ConfigurationProperty(StrategyNodeName, IsRequired = true)]
        public OptimizationStrategy Strategy
        {
            //get { return (OptimizationStrategy) Enum.Parse(typeof (OptimizationStrategy), base[_strategy].ToString()); }
            get { return OptimizationStrategy.Volume; }
        }

        [ConfigurationProperty(StrategyNodeName, IsRequired = true)]
        public int FillThreshold
        {
            //get { return int.Parse(base[_fillThreshold].ToString()); } // todo add validation
            get { return 60; }
        }

        public int HighPriorityDayThreshold
        {   //get { return int.Parse(base[_highPriorityDayThreshold].ToString()); } // todo add validation
            get { return 2; }
        }
    }
}
