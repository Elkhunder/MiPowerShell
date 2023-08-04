using Microsoft.Management.Infrastructure;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Providers.ControlProvider;

namespace MiPowerShell.Handlers.Events
{
    public class TextBox_FocusLost
    {
        private readonly Control? _tableLayoutPanel;
        public string? SelectedCommand
        {
            get; set;
        }
        public TextBox_FocusLost(Control tableLayoutPanel)
        {
            _tableLayoutPanel = tableLayoutPanel;
        }
        public void TextBox_ComputerName_FocusLost(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                TextBox? textBox = sender as TextBox;
                // get commands box to check the selected command
                if (textBox is not null && !string.IsNullOrEmpty(SelectedCommand))
                {
                    if (SelectedCommand == "Set-PrinterName")
                    {
                        string deviceName = textBox.Text;

                        var printerManager = new PrinterManager(deviceName);

                        if (_tableLayoutPanel != null)
                        {
                            ComboBox comboBox = (ComboBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "ComboBox_PrinterSelection")!;
                            comboBox.Items.Clear();
                            comboBox.Items.AddRange(printerManager.GetPrinterNames());
                        }
                    }
                }
                
            }
        }
    }
}
