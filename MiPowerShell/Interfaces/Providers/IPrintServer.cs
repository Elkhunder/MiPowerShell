using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Interfaces.Providers
{
    public interface IPrintServer
    {
        PrintQueueCollection GetPrintQueues();
        PrintQueue GetPrintQueue(string printerName);
    }

}
