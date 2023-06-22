using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport
{
    internal class MaintenanceInformation
    {
        public MaintenanceInformation() { }
        public class MaintenanceConfiguration
        {
            public MaintenanceConfiguration()
            {
                MaintenanceTime = string.Empty;
                LastBegan = string.Empty;
                LastCompleted = string.Empty;
                LastSucceeded = string.Empty;
                RebootPending = string.Empty;
                MachineUpTime = string.Empty;
            }

            public string MaintenanceTime { get; set; }
            public string LastBegan { get; set; }
            public string LastCompleted { get; set; }
            public string LastSucceeded { get; set; }
            public string RebootPending { get; set; }
            public string MachineUpTime { get; set; }
        }

        public class PowerManagement
        {
        }
    }
}
