using MiPowerShell.Arguments;
using MiPowerShell.Arguments.BiosCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Collectors.BiosCommands
{
    internal class ClearBiosPasswordInputCollector : BiosInputCollector
    {
        public ClearBiosPasswordInputCollector(Form form) : base(form) { }

        public override CommandArguments Collect()
        {
            var computerNames = CollectComputerNames();
            var remote = CollectRemote();
            var local = CollectLocal();
            var biosPassword = CollectBiosPassword();
            var newBiosPassword = new SecureString();

            return new CommandArguments(biosPassword, newBiosPassword, computerNames, remote, local);
        }
    }
}
