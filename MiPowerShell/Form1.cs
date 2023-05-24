using MiPowerShell.Collectors.CommandInputCollector;
using MiPowerShell.Collectors.BiosCommands;
using MiPowerShell.Dispatchers;
using MiPowerShell.Providers.ControlProvider;
using MiPowerShell.Handlers.Commands;
using MiPowerShell.Arguments;
using System.Diagnostics;
using System.Management.Automation;
using Microsoft.Management.Infrastructure;
using System.Windows.Forms;
using MiPowerShell.Collectors;

namespace MiPowerShell
{
    public partial class Form1 : Form
    {
        private readonly ControlFactory _controlFactory;
        private readonly CommandDispatcher _commandDispatcher;
        private readonly ErrorDispatcher _errorDispatcher;

        public Form1()
        {
            InitializeComponent();
            _controlFactory = new ControlFactory(this);
            _commandDispatcher = new CommandDispatcher();
            _errorDispatcher = new ErrorDispatcher();

        }

        private void ListBox_Commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_Remote.Select();
            Button_Remote.DialogResult = DialogResult.Yes;
            string selectedCommand = ListBox_Commands?.SelectedItem?.ToString()!;
            _controlFactory.CreateControls(selectedCommand);
        }

        private void Button_Command_Execute_Click(object sender, EventArgs e)
        {
            FormControlProvider.Instance.SetForm(this);
            var parentControl = ParentControlProvider.GetParentControlByName("TableLayoutPanel_Input");
            string selectedCommand = ListBox_Commands.SelectedItem?.ToString()!;
            TextBox? biosPassword = null;
            TextBox? newBiosPassword = null;
            TextBox? confirmNewBiosPassword = null;

            if (selectedCommand == "Set-BiosPassword")
            {
                biosPassword = (TextBox)ChildControlProvider.GetChildControlByName(parentControl, "BiosPassword");
                newBiosPassword = (TextBox)ChildControlProvider.GetChildControlByName(parentControl, "NewBiosPassword");
                confirmNewBiosPassword = (TextBox)ChildControlProvider.GetChildControlByName(parentControl, "ConfirmNewBiosPassword");
            }
            InputCollectorBase? inputCollector = null;
            switch (selectedCommand)
            {
                case "Clear-BiosPassword":
                    inputCollector = new ClearBiosPasswordInputCollector(this);
                    break;
                case "Set-BiosPassword":
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
                        inputCollector = new SetBiosPasswordInputCollector(this);
                    }
                    break;
                case "Get-CurrentUser":
                    inputCollector = new InputCollector(this);
                    break;

                case "Get-HardDriveSerial":
                    inputCollector = new InputCollector(this);
                    break;
                case "Get-WindowsVersion":
                    inputCollector = new InputCollector(this);
                    break;

            }
            // Instantiate input collector

            // Call the collect method and assign collected inputs to arguments
            var arguments = inputCollector?.Collect()!;
            _commandDispatcher.Dispatch(selectedCommand, arguments, dataGridView1);
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
            InputCollectorBase.AssignOpenFileDialog(openFileDialog1);
        }

        private void Button_Remote_Click(object sender, EventArgs e)
        {
            if (Button_Remote.Enabled && Button_Remote.Focused)
            {
                Button_Remote.DialogResult = DialogResult.Yes;
                Button_Local.DialogResult = DialogResult.None;
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
            if (Button_Local.Enabled && Button_Local.Focused)
            {
                Button_Remote.DialogResult = DialogResult.None;
                Button_Local.DialogResult = DialogResult.Yes;
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
