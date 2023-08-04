using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class PrinterInformation
    {
        public PrinterInformation(List<Printer> installedPrinters)
        {
            InstalledPrinters = installedPrinters;
        }

        public List<Printer> InstalledPrinters { get; set; }
    }

    public class Printer
    {
        public Printer(string deviceId, string driverName, string portName, PrintQueue printQueue)
        {
            DeviceId = deviceId;
            DriverName = driverName;
            PortName = portName;
            PrintQueue = printQueue;
        }

        public Printer(string deviceId, string driverName, string portName)
        {
            DeviceId = deviceId;
            DriverName = driverName;
            PortName = portName;
        }

        public string DeviceId { get; set; }
        public string DriverName { get; set; }
        public string PortName { get; set; }
        public PrintQueue PrintQueue { get; set; }
    }

    public class Defaults
    {
        public Defaults(string userAccount, string deviceName)
        {
            UserAccount = userAccount;
            DeviceId = deviceName;
        }

        public string UserAccount { get; set; }
        public string DeviceId { get; set; }
    }
}
