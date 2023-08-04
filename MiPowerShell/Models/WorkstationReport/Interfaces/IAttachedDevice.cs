using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Interfaces
{
    public interface IAttachedDevice
    {
        string? DeviceID { get; }
        string? DeviceName { get; }
        string? DeviceType { get; }
        string? Manufacturer { get; }
        string? DeviceStatus { get; }
    }
}
