using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Enums
{
    public enum ProcessorType : uint
    {
        Other = 1,
        Unknown = 2,
        CentralProcessor = 3,
        MathProcessor = 4,
        DSPProcessor = 5,
        VideoProcessor = 6
    }
}
