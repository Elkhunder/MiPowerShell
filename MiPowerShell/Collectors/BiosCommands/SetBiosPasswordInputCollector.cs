using MiPowerShell.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Collectors.BiosCommands
{
    internal class SetBiosPasswordInputCollector : BiosInputCollector
    {
        public SetBiosPasswordInputCollector(Form form) : base(form)
        {
        }

        public override CommandArguments Collect()
        {
            var computerNames = CollectComputerNames();
            var remote = CollectRemote();
            var local = CollectLocal();
            var biosPassword = CollectBiosPassword();
            var newBiosPassword = CollectNewBiosPassword();
            return new CommandArguments(biosPassword, newBiosPassword, computerNames, remote, local);
        }

        private SecureString CollectNewBiosPassword()
        {
            var newBiosPassword = new SecureString();
            if ((bool)_tableLayoutPanel_Input?.Controls.ContainsKey("NewBiosPassword")!)
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["NewBiosPassword"]!).Text;

                foreach (char c in key.ToCharArray())
                {
                    newBiosPassword.AppendChar(c);
                }
                ((TextBox)_tableLayoutPanel_Input.Controls["NewBiosPassword"]!).Text = "";
            }
            
            return newBiosPassword;
        }
    }
}
