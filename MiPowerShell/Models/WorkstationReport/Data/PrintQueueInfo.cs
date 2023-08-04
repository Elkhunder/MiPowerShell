using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class PrintQueueInfo
    {
        public PrintQueueInfo(string name, bool isTonerLow, string queueDriver, string queuePort, PrintQueueStatus queueStatus, bool isDirect)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsTonerLow = isTonerLow;
            QueueDriver = queueDriver ?? throw new ArgumentNullException(nameof(queueDriver));
            QueuePort = queuePort ?? throw new ArgumentNullException(nameof(queuePort));
            QueueStatus = queueStatus;
            IsDirect = isDirect;
        }

        public string Name { get; set; }
        public bool IsTonerLow { get; set; }
        public string QueueDriver { get; set; }
        public string QueuePort { get; set; }
        public PrintQueueStatus QueueStatus { get; set; }
        public bool IsDirect { get; set; }
    }
}
