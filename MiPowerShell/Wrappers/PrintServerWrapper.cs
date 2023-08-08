using Microsoft.Management.Infrastructure;
using MiPowerShell.Helpers;
using MiPowerShell.Interfaces.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Wrappers
{
    public class PrintServerWrapper : IPrintServer
    {
        private readonly PrintServer _printServer;

        public PrintServerWrapper(string deviceName)
        {
            _printServer = new PrintServer($@"\\{deviceName}");
        }

        public PrintQueueCollection GetPrintQueues()
        {
            return _printServer.GetPrintQueues();
        }

        public PrintQueue GetPrintQueue(string printerName)
        {
            return _printServer.GetPrintQueue(printerName);
        }
    }

    

}
