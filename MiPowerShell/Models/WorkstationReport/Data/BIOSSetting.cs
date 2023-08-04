using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class BIOSSetting
    {
        public BIOSSetting(string attributeName, string currentValue, List<string> possibleValues)
        {
            AttributeName = attributeName;
            CurrentValue = currentValue;
            PossibleValues = possibleValues;
        }

        public BIOSSetting(string attributeName, string currentValue)
        { 
            AttributeName= attributeName;
            CurrentValue = currentValue;
        }

        public string AttributeName { get; set; }
        public string CurrentValue { get; set; }
        public List<string>? PossibleValues { get; set; }
    }
}
