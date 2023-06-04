using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers
{
    public static class DeviceStatusChecked
    {
        public static bool IsDeviceOnline(string device)
        {
            Ping ping = new();
            try
            {
                PingReply reply = ping.Send(device);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }
    }
}
