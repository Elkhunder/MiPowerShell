using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Enums
{
    public enum Architecture : uint
    {
        x86 = 0,
        MIPS = 1,
        Alpha = 2,
        PowerPC = 3,
        ARM = 5,
        ia64 = 6,
        x64 = 9,
        ARM64 = 12
    }
}
