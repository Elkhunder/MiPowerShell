using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Validation
{
    public class Validator : IValidator
    {
        public Validator() { }
        public Validator(string message) { }
        public Validator(string message, Exception exception) { }
        public void Validate(object sender, CancelEventArgs e)
        {
            TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)sender;
            TableLayoutControlCollection controls = tableLayoutPanel.Controls;
            if (controls.ContainsKey("BiosPassword") && controls.ContainsKey("ConfirmBiosPassword"))
            {
                string biosPasssword = controls.Find("BiosPassword", true).First().Text;
                string confirmBiosPassword = controls.Find("ConfirmBiosPassword", true).First().Text;

                if (biosPasssword != confirmBiosPassword)
                {
                    // Deal with mismatching bios passwords
                }
                else
                {
                    // Deal with matching bios passwords
                }
            }
            foreach (Control control in controls)
            {

            }
        }
    }
}
