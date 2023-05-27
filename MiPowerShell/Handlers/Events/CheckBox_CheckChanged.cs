using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPowerShell.Handlers.Events
{
    public class CheckBox_CheckChanged
    {
        private Control _tableLayoutPanel;

        public CheckBox_CheckChanged(Control tableLayoutPanel)
        {
            _tableLayoutPanel = tableLayoutPanel;
        }

        public void CheckBox_BiosPassword_CheckChanged(object? sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender!;
            TextBox textBox = new TextBox();
            FlowLayoutPanel flowLayoutPanel = _tableLayoutPanel.Controls
                .OfType<FlowLayoutPanel>()
                .FirstOrDefault(control => control.Name == "flowLayoutPanel_BiosPassword")!;
            if (flowLayoutPanel != null)
            {
                textBox = flowLayoutPanel.Controls
                    .OfType<TextBox>()
                    .FirstOrDefault(control => control is TextBox textBox)!;

            }

            if (textBox != null)
            {
                if (checkBox.Checked)
                {
                    textBox.Enabled = true;
                    textBox.PlaceholderText = "Required";
                    textBox.Focus();
                }
                else
                {
                    textBox.Enabled = false;
                    textBox.PlaceholderText = "Optional";
                }
            }
        }
    }
}
