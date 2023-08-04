using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Enums
{
    public enum DriveType : uint
    {
        Unknown = 0,
        NoRootDirectory = 1,
        RemovableDisk = 2,
        LocalDisk = 3,
        NetworkDrive = 4,
        CompactDisc = 5,
        RAMDisk = 6
    }
}
