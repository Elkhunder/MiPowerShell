using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Enums
{
    public enum CpuStatus : uint
    {
        Unknown = 0,
        CPUEnabled = 1,
        CPUDisabledByUserViaBIOSSetup = 2,
        CPUDisabledByBIOS_POSTError = 3,
        CPUisIdle = 4,
        Reserved1 = 5,
        Reserved2 = 6,
        Other = 7
    }
}
