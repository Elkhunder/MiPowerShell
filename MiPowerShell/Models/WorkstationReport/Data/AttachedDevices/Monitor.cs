using MiPowerShell.Models.WorkstationReport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data.AttachedDevices
{
    public class Monitor : IAttachedDevice
    {

        public int ScreenWidth {  get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenResolution { get; set; }
        public int RefreshRate { get; set; }
        public bool IsPrimary { get; set; }

        public string? DeviceID { get; set; }

        public string? DeviceName { get; set; }

        public string? DeviceType { get; set; }

        public string? Manufacturer { get; set; }

        public string? DeviceStatus { get; set; }
    }
}
