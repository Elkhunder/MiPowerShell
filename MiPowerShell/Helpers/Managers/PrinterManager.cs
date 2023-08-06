using Microsoft.CodeAnalysis;
using Microsoft.Management.Infrastructure;
using Namotion.Reflection;
using System.Printing;

namespace MiPowerShell.Helpers.Managers
{
    public class PrinterManager
    {
        private readonly string _deviceName;
        private readonly BackgroundTaskManager _taskManager;
        private readonly PrintServer _printServer;
        private CimInstance[] _win32Printer;
        private CimHandler _cimHandler;
        public PrinterManager(string deviceName)
        {
            _deviceName = deviceName;
            _taskManager = new BackgroundTaskManager();
            _printServer = new PrintServer($@"\\{deviceName}");

            _cimHandler = new(deviceName);
            _win32Printer = _cimHandler.GetInstances(@"root\cimv2", "Win32_Printer");
            
        }

        public PrintQueueCollection GetPrinters()
        {
            return _printServer.GetPrintQueues();
        }

        public PrintQueue GetPrinter(string printerName)
        {
            return _printServer.GetPrintQueue(printerName);
        }

        public CimInstance[] GetPrintersWmi()
        {
            return _win32Printer;
        }

        public CimInstance? GetPrinterWmi(string printerName)
        {
            return _win32Printer.FirstOrDefault(printer =>
            {
                object? deviceID = printer.TryGetPropertyValue<object?>("DeviceID");
                return deviceID?.ToString() == printerName;
            });
        }

        public string[] GetPrinterNames()
        {
            var printQueues = _printServer.GetPrintQueues();
            var printerNames = new string[printQueues.Count()];
            int i = 0;

            foreach (var queue in printQueues)
            {
                printerNames[i] = queue.Name;
                i++;
            }
            return printerNames;
        }

        public string[] GetPrinterNames(string deviceName)
        {
            using (var printServer = new PrintServer(deviceName))
            {
                var printQueues = printServer.GetPrintQueues();
                var printerNames = new string[printQueues.Count()];
                int i = 0;

                foreach (var queue in printQueues)
                {
                    printerNames[i] = queue.Name;
                    i++;
                }
                return printerNames;
            }
        }

        public List<string> GetPrinterNamesWmi()
        {
            List<string> printerNames = new List<string>();
            foreach(CimInstance printer in _win32Printer)
            {
                object? deviceID = printer.TryGetPropertyValue<object?>("deviceID");
                string? printerName = deviceID?.ToString();
                if (printerName is not null)
                {
                    printerNames.Add(printerName);
                }
            }
            return printerNames;
        }

        public string[] GetPrinterList()
        {
            string[] printerNames = new string[_win32Printer.Length];
            for (int i = 0; i < printerNames.Length; i++)
            {
                object? deviceID = _win32Printer.TryGetPropertyValue<object?>("deviceID");
                string? printerName = deviceID?.ToString();
                if (printerName is not null)
                {
                    printerNames[i] = printerName;
                }
            }
            return printerNames;
        }

    }
}
