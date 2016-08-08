using System;
using System.Configuration;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;

namespace CargosService.Configuration.Implementation.Settings
{
    public class PackagingConfiguration : IPackagingConfiguration
    {
        private const string ErrorMessage = "Looks like, configuration {0} has wrong value. Expected: {1}, but was {2}";
        private const string StrategyNodeName = "Strategy";
        private const string FillThresholdNodeName = "FillThreshold";
        private const string HighPriorityDayThresholdNodeName = "HighPriorityDayThreshold";

        [ConfigurationProperty(StrategyNodeName, IsRequired = true)]
        public OptimizationStrategy Strategy
        {
            get
            {
                OptimizationStrategy result;
                var value = ConfigurationManager.AppSettings[StrategyNodeName];

                var isParsed = Enum.TryParse(value, out result);
                if (!isParsed)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, StrategyNodeName, "Volume or Weight", value));
                }

                return result;
            }
        }

        [ConfigurationProperty(FillThresholdNodeName, DefaultValue = 60, IsRequired = true)]
        public int FillThreshold
        {
            get
            {
                int result;
                var value = ConfigurationManager.AppSettings[FillThresholdNodeName];
                var isParsed = int.TryParse(value, out result);

                if (!isParsed)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, FillThresholdNodeName, "int", value));
                }

                if (result < 0 || result > 100)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, HighPriorityDayThresholdNodeName, "[0; 100]", result));
                }

                return result;
            }
        }

        [ConfigurationProperty(HighPriorityDayThresholdNodeName, DefaultValue = 2, IsRequired = true)]
        public int HighPriorityDayThreshold
        {
            get
            {
                int result;
                var value = ConfigurationManager.AppSettings[HighPriorityDayThresholdNodeName];
                var isParsed = int.TryParse(value, out result);

                if (!isParsed)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, HighPriorityDayThresholdNodeName, "int", value));
                }

                if (result <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessage, HighPriorityDayThresholdNodeName, "> 0", result));
                }

                return result;
            }
        }
    }
}
