using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MiPowerShell;
using MiPowerShell.Controls;
using MiPowerShell.Validation;

public class ControlFactory : IErrorProvider
{
    private readonly Form _form;
    private Control _tableLayoutPanel;
    private ErrorProvider _errorProvider;
    private Validator _validator;

    public ControlFactory(Form form)
    {
        _form = form;
        Control[] tableLayoutPanel = form.Controls.Find("TableLayoutPanel_Input", true);
        _tableLayoutPanel = tableLayoutPanel[0];
        _errorProvider = new ErrorProvider();
        _errorProvider.BlinkRate = 1000;
        _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        _validator = new Validator();
    }

    public void CreateControls(string selectedCommand)
    {
        DisposeControls();
        switch (selectedCommand)
        {
            case "Clear-BiosPassword":
                CreateComputerNameControl();
                CreatePasswordControl(selectedCommand);
                break;
            case "Remove-UserProfile":
                CreateComputerNameControl();
                CreateUsernameControl();
                break;
            case "Set-BiosPassword":
                CreateComputerNameControl();
                CreatePasswordControl(selectedCommand);
                CreateNewBiosPasswordControl();
                CreateConfirmNewPasswordControl();
                break;
            case "Get-HardDriveSerial":
                CreateComputerNameControl();
                break;
            case "Get-Printers":
                CreateComputerNameControl();
                break;
            case "Install-Language":
                CreateComputerNameControl();
                CreateLanguageControl();
                break;
            case "Rename-Printers":
                CreateComputerNameControl();
                CreateOldPrinterNameControl();
                CreateNewPrinterNameControl();
                break;
            case "Set-NetworkProfile":
                CreateComputerNameControl();
                CreateProfileControl();
                break;
            case "Set-Printers":
                CreateComputerNameControl();
                CreatePrinterControl();
                break;
            case "Get-CurrentUser":
                CreateComputerNameControl();
                break;
            case "Get-UserProfile":
                CreateComputerNameControl();
                CreateUsernameControl();
                break;
            case "Add-Shortcut":
                CreateComputerNameControl();
                CreateShortcutControl();
                break;
            case "Uninstall-Software":
                CreateComputerNameControl();
                CreateSoftwareControl();
                break;
            default:
                return;
                //throw new ArgumentException("Invalid command selected", nameof(selectedCommand));
        }
    }

    private void DisposeControls()
    {
        foreach (Control control in _tableLayoutPanel.Controls)
        {
            if(control is IDisposable disposable) disposable.Dispose();
        }
        _tableLayoutPanel.Controls.Clear();
    }

    private void CreateComputerNameControl()
    {
        Label label = new Label();
        label.Text = "Enter Computer Name:";
        label.Dock= DockStyle.Fill;
        label.AutoSize = true;
        TextBox textBox = new TextBox();
        textBox.Name = "Computers";
        textBox.Tag = "Computers";
        textBox.Dock= DockStyle.Left;
        textBox.AutoSize = true;
        textBox.PlaceholderText = "Required";

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //TermIdValidator termIdValidator= new TermIdValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(termIdValidator.Validate);

        _tableLayoutPanel.Controls.Add(label);
        _tableLayoutPanel.Controls.Add(textBox);
        


    }

    private void CreatePasswordControl(string selectedCommand)
    {
        Label label = new Label();
        label.Text = "Enter Bios Password:";
        label.Dock= DockStyle.Fill;
        label.AutoSize= true;
        
        TextBox textBox = new TextBox();
        textBox.PasswordChar = '*';
        textBox.Name = "BiosPassword";
        textBox.Tag = "BiosPassword";

        if(selectedCommand == "Set-BiosPassword")
        {
            textBox.PlaceholderText = "Optional";
            textBox.Enabled = false;

            CheckBox checkBox = new CheckBox();
            checkBox.Name = "CheckBox_BiosPassword";
            checkBox.Checked = false;
            checkBox.Text = "Update existing BIOS password";
            checkBox.AutoSize = true;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Name = "flowLayoutPanel_BiosPassword";
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            _tableLayoutPanel.Controls.Add(label);
            flowLayoutPanel.Controls.Add(checkBox);
            flowLayoutPanel.Controls.Add(textBox);
            _tableLayoutPanel.Controls.Add(flowLayoutPanel);
        }
        if(selectedCommand == "Clear-BiosPassword")
        {
            textBox.PlaceholderText = "Required";
            _tableLayoutPanel.Controls.Add(label);
            _tableLayoutPanel.Controls.Add(textBox);
        }

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //BiosPasswordValidator biosPasswordValidator = new BiosPasswordValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(biosPasswordValidator.Validate);

        
    }

    private void CheckBox_CheckedChanged(object? sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender!;
        TextBox textBox = new TextBox();
        FlowLayoutPanel flowLayoutPanel = _tableLayoutPanel.Controls
            .OfType<FlowLayoutPanel>()
            .FirstOrDefault(control => control.Name == "flowLayoutPanel_BiosPassword")!;
        if(flowLayoutPanel != null)
        {
            textBox = flowLayoutPanel.Controls
                .OfType<TextBox>()
                .FirstOrDefault(control => control  is TextBox textBox)!;

        }

        if (textBox != null)
        {
            textBox.Enabled = checkBox.Checked;
        }
    }

    private void CreateNewBiosPasswordControl()
    {
        Label label = new Label();
        label.Text = "Enter New Bios Password";
        label.Dock= DockStyle.Fill;
        label.AutoSize= true;

        TextBox textBox = new TextBox();
        textBox.PasswordChar = '*';
        textBox.Name = "NewBiosPassword";
        textBox.Tag = "NewBiosPassword";
        textBox.PlaceholderText = "Required";

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //BiosPasswordValidator biosPasswordValidator = new BiosPasswordValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(biosPasswordValidator.Validate);

        _tableLayoutPanel.Controls.Add(label);
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateConfirmNewPasswordControl()
    {
        Label label = new Label();
        label.Text = "Confirm Bios Password";
        label.Dock= DockStyle.Fill;
        label.AutoSize= true;

        TextBox textBox = new TextBox();
        textBox.PasswordChar = '*';
        textBox.Name = "ConfirmNewBiosPassword";
        textBox.Tag = "ConfirmNewBiosPassword";
        textBox.PlaceholderText = "Required";

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //BiosPasswordValidator biosPasswordValidator = new BiosPasswordValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(biosPasswordValidator.Validate);

        _tableLayoutPanel.Controls.Add(label);
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateUsernameControl()
    {
        Label label = new Label();
        label.Text = "Username:";
        _tableLayoutPanel.Controls.Add(label);

        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateLanguageControl()
    {
        Label label = new Label();
        label.Text = "Language:";
        _tableLayoutPanel.Controls.Add(label);

        ComboBox comboBox = new ComboBox();
        comboBox.Items.AddRange(new[] { "English", "French", "German", "Spanish" });
        _tableLayoutPanel.Controls.Add(comboBox);
    }

    private void CreateOldPrinterNameControl()
    {
        Label label = new Label();
        label.Text = "Old Printer Name:";
        _tableLayoutPanel.Controls.Add(label);

        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateNewPrinterNameControl()
    {
        Label label = new Label();
        label.Text = "New Printer Name:";
        _tableLayoutPanel.Controls.Add(label);

        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateProfileControl()
    {
        Label label = new Label();
        label.Text = "Network Profile:";
        _tableLayoutPanel.Controls.Add(label);

        ComboBox comboBox = new ComboBox();
        comboBox.Items.AddRange(new[] { "Public", "Private", "Domain" });
        _tableLayoutPanel.Controls.Add(comboBox);
    }

    private void CreatePrinterControl()
    {
        Label label = new Label();
        label.Text = "Printer:";
        _tableLayoutPanel.Controls.Add(label);

        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateShortcutControl()
    {
        Label label = new Label();
        label.Text = "Shortcut:";
        _tableLayoutPanel.Controls.Add(label);

        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    private void CreateSoftwareControl()
    {
        Label label = new Label();
        label.Text = "Software:";
        _tableLayoutPanel.Controls.Add(label);
        TextBox textBox = new TextBox();
        _tableLayoutPanel.Controls.Add(textBox);
    }

    public void SetError(Control control, string errorMessage)
    {
        throw new NotImplementedException();
    }
}
