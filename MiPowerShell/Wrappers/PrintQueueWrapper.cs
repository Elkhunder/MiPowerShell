using MiPowerShell.Interfaces.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Wrappers
{
    public class PrintQueueWrapper : IPrintQueueWrapper
    {
        private readonly PrintQueue _printQueue;

        public PrintQueueWrapper(PrintQueue printQueue)
        {
            _printQueue = printQueue;
        }

        public string Name => _printQueue.Name;
        // Implement other properties or methods you need from PrintQueue here
    }
}
