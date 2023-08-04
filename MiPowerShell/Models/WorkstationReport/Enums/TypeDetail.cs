using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Enums
{
    [Flags]
    public enum TypeDetail : uint
    {
        Reserved = 1,
        Other = 2,
        Unknown = 4,
        FastPaged = 8,
        StaticColumn = 16,
        PseudoStatic = 32,
        RAMBUS = 64,
        Synchronous = 128,
        CMOS = 256,
        EDO = 512,
        WindowDRAM = 1024,
        CacheDRAM = 2048,
        NonVolatile = 4096
    }
}
