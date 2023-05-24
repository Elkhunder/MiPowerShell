using MiPowerShell.Arguments;
using MiPowerShell.Collectors.CommandInputCollector;
using System.Security;

namespace MiPowerShell.Collectors.BiosCommands
{
    internal abstract class BiosInputCollector : InputCollectorBase
    {
        public BiosInputCollector(Form form) : base(form) { }

        public override CommandArguments Collect()
        {
            var computerNames = CollectComputerNames();
            var remote = CollectRemote();
            var local = CollectLocal();
            var biosPassword = CollectBiosPassword();
            var newBiosPassword = new SecureString();

            return new CommandArguments(biosPassword, newBiosPassword, computerNames, remote, local);
        }

        public SecureString CollectBiosPassword()
        {
            // Collect bios password input
            var biosPassword = new SecureString();

            if (_tableLayoutPanel_Input != null && (bool)_tableLayoutPanel_Input.Controls.ContainsKey("BiosPassword"))
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["BiosPassword"]!).Text;

                foreach (char c in key.ToCharArray())
                {
                    biosPassword.AppendChar(c);
                }
                ((TextBox)_tableLayoutPanel_Input.Controls["BiosPassword"]!).Text = "";
            }
            return biosPassword;
        }
    }
}
