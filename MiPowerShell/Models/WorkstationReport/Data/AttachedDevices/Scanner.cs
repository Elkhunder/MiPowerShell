using MiPowerShell.Models.WorkstationReport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data.AttachedDevices
{
    internal class Scanner : IAttachedDevice
    {
        public string DeviceID => throw new NotImplementedException();

        public string DeviceName => throw new NotImplementedException();

        public string DeviceType => throw new NotImplementedException();

        public string Manufacturer => throw new NotImplementedException();

        public string DeviceStatus => throw new NotImplementedException();
    }
}
