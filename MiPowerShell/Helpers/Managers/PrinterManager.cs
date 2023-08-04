using Microsoft.CodeAnalysis;
using Microsoft.Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers.Managers
{
    public class PrinterManager
    {
        private readonly string _deviceName;
        private readonly BackgroundTaskManager _taskManager;
        private readonly PrintServer _printServer;
        private CimInstance[]? _cimInstances;
        public PrinterManager(string deviceName)
        {
            _deviceName = deviceName;
            _taskManager = new BackgroundTaskManager();
            _printServer = new PrintServer($@"\\{deviceName}");
            
        }

        public PrinterManager(string deviceName, BackgroundTaskManager backgroundTaskManager, PrintServer printServer)
        {
            _deviceName = deviceName;
            _taskManager = backgroundTaskManager;
            _printServer = printServer;
        }

        public PrintQueueCollection GetPrinters()
        {
            return _printServer.GetPrintQueues();
        }

        public PrintQueueCollection GetPrinters(string deviceName)
        {
            return (new PrintServer(deviceName)).GetPrintQueues();
        }

        public PrintQueue GetPrinter(string printerName)
        {
            return _printServer.GetPrintQueue(printerName);
        }

        public PrintQueue GetPrinter(string printerName, string deviceName)
        {
            return (new PrintServer(deviceName)).GetPrintQueue(printerName);
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

        public PrinterManager(CimInstance[]? cimInstances)
        {
            _cimInstances = cimInstances;
        }

        public string[] GetPrinterList()
        {
            if (_cimInstances == null)
            {
                return new[] { "" };
            }
            string[] printerNames = new string[_cimInstances.Length];

            for (int i = 0; i < printerNames.Length; i++)
            {
                printerNames[i] = (string)_cimInstances[i].CimInstanceProperties["name"].Value;
            }
            return printerNames;
        }

    }
}
