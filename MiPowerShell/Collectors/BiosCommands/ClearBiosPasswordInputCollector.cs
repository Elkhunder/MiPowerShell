using MiPowerShell.Arguments;
using System.Security;

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
