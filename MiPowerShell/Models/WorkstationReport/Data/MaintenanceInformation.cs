using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class MaintenanceInformation
    {
        public Configuration Configuration { get; set; }
        public PowerManagement PowerManagement { get; set; }
        public MaintenanceInformation()
        {
            Configuration = new Configuration();
            PowerManagement = new PowerManagement();

        }



    }

    public class PowerManagement
    {
        public PowerManagement()
        {
            SystemUnitManagement = string.Empty;
        }

        public string SystemUnitManagement { get; set; }
    }

    public class Configuration
    {
        public Configuration()
        {
            MaintenanceTime = string.Empty;
            LastBegan = string.Empty;
            LastCompleted = string.Empty;
            LastSucceeded = string.Empty;
            LastResult = string.Empty;
            RebootPending = false;
            MachineUpTime = string.Empty;
        }

        public string MaintenanceTime { get; set; }
        public string LastBegan { get; set; }
        public string LastCompleted { get; set; }
        public string LastSucceeded { get; set; }
        public string LastResult { get; set; }
        public bool? RebootPending { get; set; }
        public string MachineUpTime { get; set; }
    }
}
