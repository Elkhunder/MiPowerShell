using MiPowerShell.Arguments;
using MiPowerShell.Collectors.CommandInputCollector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Collectors
{
    internal class InputCollector : InputCollectorBase
    {
        public InputCollector(Form form) : base(form)
        {
        }
        public override CommandArguments Collect()
        {
            var computerNames = CollectComputerNames();
            var remote = CollectRemote();
            var local = CollectLocal();
            return new CommandArguments(computerNames, remote, local);
        }
    }
}
