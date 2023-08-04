using Microsoft.Management.Infrastructure;
using MiPowerShell.Models.WorkstationReport.Data.AttachedDevices;
using MiPowerShell.Models.WorkstationReport.Interfaces;
using Namotion.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;
using Monitor = MiPowerShell.Models.WorkstationReport.Data.AttachedDevices.Monitor;

namespace MiPowerShell.Helpers.Managers
{
    public class AttachedDeviceManager
    {
        public IReadOnlyList<IAttachedDevice>? AttachedDevices 
        {
            get { return  _attachedDevices.AsReadOnly(); }
        }
        private List<IAttachedDevice> _attachedDevices;
        private string _deviceName;

        public AttachedDeviceManager(string deviceName)
        {
            _attachedDevices = new List<IAttachedDevice>();
            _deviceName = deviceName;
            CimHandler cimHandler = new(deviceName);
            WIA.DeviceManager wiaDeviceManager = new WIA.DeviceManager();

            RefreshDeviceList(deviceName, cimHandler, wiaDeviceManager);
        }

        

        private void RefreshDeviceList(string deviceName, CimHandler cimHandler, WIA.DeviceManager wiaDeviceManager)
        {
            var WmiMonitorID = cimHandler.GetInstances(@"root\wmi", "WmiMonitorID");
            foreach (var monitor  in WmiMonitorID)
            {
                new Monitor
                {
                    DeviceName = monitor.CimInstanceProperties["UserFriendlyName"].Value.ToString(),
                    DeviceID = monitor.CimInstanceProperties["SerialNumberID"].Value.ToString(),

                };
            }

        }

        public List<IAttachedDevice> GetDevices(string deviceType)
        {
            List<IAttachedDevice> devices = new List<IAttachedDevice>();

            foreach (var device in _attachedDevices)
            {
                if(device.DeviceType == deviceType)
                {
                    devices.Add(device);
                }
            }
            return devices;
        }
    }
}
