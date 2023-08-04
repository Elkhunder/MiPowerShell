using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    
    public class BIOSInformation
    {
        public BIOSInformation(string systemModel, string bIOSVersion, string bIOSDate, IEnumerable<string> bootOrder, List<BIOSSetting> biosSettings)
        {
            SystemModel = systemModel;
            BIOSVersion = bIOSVersion;
            BIOSDate = bIOSDate;
            BootOrder = bootOrder;
            BIOSSettings = biosSettings;

        }

        public string SystemModel { get; set; }
        public string BIOSVersion { get; set; }
        public string BIOSDate { get; set; }
        public IEnumerable<string> BootOrder { get; set; }
        public List<BIOSSetting> BIOSSettings { get; set; }
    }
}
