using Microsoft.Management.Infrastructure;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Providers.ControlProvider;

namespace MiPowerShell.Handlers.Events
{
    public class TextBox_FocusLost
    {
        private readonly Control? _tableLayoutPanel;
        public TextBox_FocusLost(Control tableLayoutPanel)
        {
            _tableLayoutPanel = tableLayoutPanel;
        }
        public void TextBox_ComputerName_FocusLost(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            // get commands box to check the selected command

            if (!string.IsNullOrEmpty(_selectedCommand) && _selectedCommand == "Set-PrinterName")
            {
                string termId = textBox.Text;
                string namespaceName = @"root\cimv2";
                string className = "CIM_Printer";

                CimHandler cimHandler = new CimHandler(termId, namespaceName, className);
                CimInstance[] cimInstances = cimHandler.CimInstances;
                PrinterManager printerManager = new(cimInstances);

                if (_tableLayoutPanel != null)
                {
                    ComboBox comboBox = (ComboBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "ComboBox_PrinterSelection")!;

                    comboBox.Items.AddRange(printerManager.GetPrinterList());
                }
            }
        }
    }
}
