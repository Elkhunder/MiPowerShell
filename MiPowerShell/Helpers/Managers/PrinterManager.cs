using Microsoft.CodeAnalysis;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Interfaces.Providers;
using MiPowerShell.Wrappers;
using Namotion.Reflection;
using System.Printing;

namespace MiPowerShell.Helpers.Managers
{
    public class PrinterManager
    {
        private readonly string _deviceName;
        private readonly BackgroundTaskManager _taskManager;
        private IPrintServer _printServer;
        private ICimHandler _cimHandler;

        public PrinterManager(string deviceName, IPrintServer printServer, ICimHandler cimHandler)
        {
            _deviceName = deviceName;
            _taskManager = new BackgroundTaskManager();
            _printServer = printServer;
            _cimHandler = cimHandler;
        }
        public PrinterManager(string deviceName) : this(deviceName, new PrintServerWrapper(deviceName), new CimHandler(deviceName))
        {
            _deviceName = deviceName;
            _taskManager = new BackgroundTaskManager();
        }

        public PrintQueueCollection GetPrinters()
        {
            return _printServer.GetPrintQueues();
        }

        public CimInstance[] GetPrintersWmi()
        {
            return _cimHandler.GetInstances(@"root\cimv2", "Win32_Printer");
        }

        public PrintQueue? GetPrinter(string printerName)
        {
            PrintQueueCollection printQueues = GetPrinters();
            return printQueues.FirstOrDefault(printer =>
            {
                return printer.Name == printerName;
            });
        }

        public PrintQueue GetPrinterNative(string printerName)
        {
            return _printServer.GetPrintQueue(printerName);
        }

        public CimInstance? GetPrinterWmi(string printerName)
        {
            CimInstance[] printers = GetPrintersWmi();
            return printers.FirstOrDefault(printer =>
            {
                object? deviceID = printer.TryGetPropertyValue<object?>("DeviceID");
                return deviceID?.ToString() == printerName;
            });
        }

        public string[] GetPrinterNames()
        {
            PrintQueueCollection printQueues = GetPrinters();

            try
            {
                return printQueues.Select(queue => queue.Name).ToArray();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public string[] GetPrinterNames(string deviceName)
        {
            try
            {
                using (var printServer = new PrintServer($@"\\{deviceName}"))
                {
                    var printQueues = printServer.GetPrintQueues();
                    return printQueues.Select(queue => queue.Name).ToArray();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public string?[] GetPrinterNamesWmi()
        {
            CimInstance[] printers = GetPrintersWmi();

            try
            {
                return printers.Select(printer => printer.CimInstanceProperties["DeviceID"].Value as string).ToArray();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
