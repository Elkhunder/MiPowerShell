using MiPowerShell.Dispatchers;
using MiPowerShell.Providers.ControlProvider;
using MiPowerShell.Collectors;
using MiPowerShell.Models;
using MiPowerShell.Helpers;
using Microsoft.CodeAnalysis;

namespace MiPowerShell
{
    public partial class Form1 : Form
    {
        private readonly Commands _commands;
        private readonly ControlFactory _controlFactory;
        private readonly CommandDispatcher _commandDispatcher;
        private readonly ErrorDispatcher _errorDispatcher;
        private readonly InputCollector _inputCollector;
        private string? _selectedCommand;
        private readonly Control _tableLayoutPanel;

        public Form1()
        {
            InitializeComponent();
            FormControlProvider.Instance.SetForm(this);
            _commands = new Commands();
            _controlFactory = new ControlFactory(this);
            _commandDispatcher = new CommandDispatcher();
            _errorDispatcher = new ErrorDispatcher();
            _inputCollector = new InputCollector(this);
            _tableLayoutPanel = ParentControlProvider.GetParentControlByName("TableLayoutPanel_Input");

            ListBox_Commands.BeginUpdate();
            ListBox_Commands.DataSource = _commands.ActiveCommands;
            ListBox_Commands.ClearSelected();
            ListBox_Commands.EndUpdate();
        }

        private void ListBox_Commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_Remote.Select();
            _inputCollector.RemoteDevice = true;
            _selectedCommand = ListBox_Commands?.SelectedItem?.ToString()!;
            _controlFactory.CreateControls(_selectedCommand);
        }

        private void Button_Command_Execute_Click(object sender, EventArgs e)
        {
            if (_selectedCommand != null)
            {
                if (_selectedCommand == "Set-BiosPassword")
                {
                    TextBox biosPassword = (TextBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "BiosPassword");
                    TextBox newBiosPassword = (TextBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "NewBiosPassword");
                    TextBox confirmNewBiosPassword = (TextBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "ConfirmNewBiosPassword");

                    if (newBiosPassword == null || confirmNewBiosPassword == null) return;

                    if (newBiosPassword.Text == null || newBiosPassword.Text == "")
                    {
                        MessageBox.Show("Missing required field: 'NewBiosPassword'");
                        return;
                    }
                    if (confirmNewBiosPassword.Text == null || confirmNewBiosPassword.Text == "")
                    {
                        MessageBox.Show("Missing required field: ConfirmNewBiosPassword");
                        return;
                    }
                    if (newBiosPassword?.Text != confirmNewBiosPassword?.Text)
                    {
                        MessageBox.Show("New Bios Password does not match");
                        return;
                    }
                    else
                    {
                        confirmNewBiosPassword!.Text = "";
                    }
                }

                var arguments = _inputCollector.Collect();
                _commandDispatcher.Dispatch(_selectedCommand, arguments, dataGridView1);
            }
        }

        private void Button_Command_Clear_Click(object sender, EventArgs e)
        {
            // Change the selected index to -1, this essentially removes the currently selected item
            ListBox_Commands.SelectedIndex = -1;

            // Clear each text box control in the input flow layout panel
            foreach (Control control in this.TableLayoutPanel_Input.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void Button_Command_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            var dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            _inputCollector.AssignOpenFileDialog(openFileDialog1);
        }

        private void Button_Remote_Click(object sender, EventArgs e)
        {
            if (Button_Remote.Enabled && Button_Remote.Focused)
            {
                Button_Remote.DialogResult = DialogResult.Yes;
                _inputCollector.RemoteDevice = true;
                Button_Local.DialogResult = DialogResult.None;
                _inputCollector.LocalDevice = false;
            }
            foreach (Control control in TableLayoutPanel_Input.Controls)
            {
                if (control.Name is "Computers" && control.Enabled == false)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Enabled = true;
                    textBox.PlaceholderText = "Required";
                }
            }
        }

        private void Button_Local_Click(object sender, EventArgs e)
        {
            ComboBox printerSelection = (ComboBox)ChildControlProvider.GetChildControlByName(_tableLayoutPanel, "ComboBox_PrinterSelection");
            if (_selectedCommand != null && _selectedCommand == "Set-PrinterName")
            {
                Optional<string[]> printerList = PrinterHandler.GetPrinterList("localhost");
                if (printerList.HasValue)
                {
                    string[] printerNames = printerList.Value;
                    printerSelection.Items.Clear();
                    printerSelection.Items.AddRange(printerNames);
                }

            }
            if (Button_Local.Enabled && Button_Local.Focused)
            {
                Button_Remote.DialogResult = DialogResult.None;
                _inputCollector.RemoteDevice = false;
                Button_Local.DialogResult = DialogResult.Yes;
                _inputCollector.LocalDevice = true;
            }

            foreach (Control control in TableLayoutPanel_Input.Controls)
            {
                if (control.Name is "Computers" && control.Enabled == true)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Enabled = false;
                    textBox.Text = string.Empty;
                    textBox.PlaceholderText = string.Empty;
                }
            }
        }

        private void Button_Local_MouseHover(object sender, EventArgs e) { }

        private void Button_Remote_MouseHover(object sender, EventArgs e) { }

        private void Button_File_MouseHover(object sender, EventArgs e) { }

        private void Button_Command_Execute_MouseHover(object sender, EventArgs e) { }

        private void Button_Command_Clear_MouseLeave(object sender, EventArgs e) { }

        private void Button_Command_Cancel_MouseHover(object sender, EventArgs e) { }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
