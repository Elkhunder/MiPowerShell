using MiPowerShell.Controls;
using MiPowerShell.Handlers.Events;
using MiPowerShell.Validation;

public class ControlFactory : IErrorProvider
{
    private readonly Form _form;
    private readonly Control _tableLayoutPanel;
    private readonly ErrorProvider _errorProvider;
    private readonly Validator _validator;
    private readonly int _controlWidth = 100;
    private readonly ComboBox_IndexChanged _comboBox_IndexChanged;
    private readonly CheckBox_CheckChanged _checkBox_CheckChanged;
    private readonly TextBox_FocusLost _textBox_FocusLost;

    public ControlFactory(Form form)
    {
        _form = form;
        Control[] tableLayoutPanel = form.Controls.Find("TableLayoutPanel_Input", true);
        _tableLayoutPanel = tableLayoutPanel[0];
        _errorProvider = new ErrorProvider();
        _errorProvider.BlinkRate = 1000;
        _comboBox_IndexChanged = new ComboBox_IndexChanged();
        _checkBox_CheckChanged = new CheckBox_CheckChanged(_tableLayoutPanel);
        _textBox_FocusLost = new TextBox_FocusLost(_tableLayoutPanel);
        _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        _validator = new Validator();
    }

    public void CreateControls(string selectedCommand)
    {
        _textBox_FocusLost.SelectedCommand = selectedCommand;
        DisposeControls();
        switch (selectedCommand)
        {
            case "Add-Shortcut":
                CreateComputerNameControl();
                CreateShortcutControl();
                break;
            case "Clear-BiosPassword":
                CreateComputerNameControl();
                CreatePasswordControl(selectedCommand);
                break;
            case "Get-CurrentUser":
                CreateComputerNameControl();
                break;
            case "Get-HardDriveSerial":
                CreateComputerNameControl();
                break;
            case "Get-Printers":
                CreateComputerNameControl();
                break;
            case "Get-UserProfile":
                CreateComputerNameControl();
                CreateUsernameControl();
                break;
            case "Get-WindowsVersion":
                CreateComputerNameControl();
                break;
            case "Get-WorkstationReport":
                CreateComputerNameControl();
                break;
            case "Install-Language":
                CreateComputerNameControl();
                CreateLanguageControl();
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
            case "Set-NetworkProfile":
                CreateComputerNameControl();
                CreateProfileControl();
                break;
            case "Set-Printers":
                CreateComputerNameControl();
                break;
            case "Set-PrinterName":
                CreateComputerNameControl(_textBox_FocusLost.TextBox_ComputerName_FocusLost);
                CreatePrinterSelectionControl();
                CreateNewPrinterNameControl();
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
        CreateLabelControl("Enter Computer Name:");
        CreateTextBoxControl("Required", "Computers", "Computers");
    }

    private void CreateComputerNameControl(EventHandler eventHandler)
    {
        CreateLabelControl("EnterComputerName");
        CreateTextBoxControl("Required", "Computers", "Computers", eventHandler);
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
            checkBox.CheckedChanged += _checkBox_CheckChanged.CheckBox_BiosPassword_CheckChanged;

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
        CreateLabelControl("UserName");
        CreateTextBoxControl("Required", "TextBox_UserName", "UserName");
    }

    private void CreateLanguageControl()
    {
        CreateLabelControl("Select Language:");
        CreateComboBoxControl("ComboBox_LanguageSelection", "Language", new[] { "English", "French", "German", "Spanish" }, true);
    }

    private void CreateNewPrinterNameControl()
    {
        CreateLabelControl("New Printer Name:");
        CreateTextBoxControl("Required", "TextBox_NewPrinterName", "NewPrinterName");
    }

    private void CreatePrinterSelectionControl()
    {

        CreateLabelControl("Select Printer:");
        CreateComboBoxControl("ComboBox_PrinterSelection", "PrinterName", new[] {"Yes","No"}, true);
    }

    private void CreateComboBoxControl(string name, string tag, bool dropDownMenu = false)
    {
        ComboBox comboBox = new ComboBox();
        comboBox.Name = name;
        comboBox.Tag = tag;

        if (dropDownMenu)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        _tableLayoutPanel.Controls.Add(comboBox);
    }

    private ComboBox CreateComboBoxControl(string name, string tag, string[]? range = null, bool dropDownMenu = false, EventHandler? eventHandler = null)
    {
        ComboBox comboBox = new ComboBox();
        comboBox.Name = name;
        comboBox.Tag = tag;
        if (eventHandler != null)
        {
            comboBox.SelectedIndexChanged += eventHandler;
        }
        if (range != null)
        {
            comboBox.Items.AddRange(range);
        }
        if(dropDownMenu)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        _tableLayoutPanel.Controls.Add(comboBox);

        return comboBox;
    }

    private void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        ComboBox comboBox;
        if (sender != null)
        {
            comboBox = (ComboBox)sender;
        }
        else
        {
            return;
        }

        if (comboBox != null && comboBox.Name == "ComboBox_PrinterSelection");
        
    }

    private void CreateTextBoxControl(string placeholderText)
    {
        TextBox textBox = new TextBox();
        textBox.PlaceholderText = placeholderText;
        textBox.Width = _controlWidth;
        _tableLayoutPanel.Controls.Add(textBox);

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //TermIdValidator termIdValidator= new TermIdValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(termIdValidator.Validate);
    }

    private void CreateTextBoxControl(string placeholderText, string name, string tag, EventHandler? eventHandler = null)
    {
        TextBox textBox = new()
        {
            PlaceholderText = placeholderText,
            Name = name,
            Tag = tag,
            Dock = DockStyle.Fill,
            Width = _controlWidth
        };
        _tableLayoutPanel.Controls.Add(textBox);

        if (eventHandler != null)
        {
            textBox.LostFocus += eventHandler;
        }

        //_errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleRight);
        //_errorProvider.SetIconPadding(textBox, 2);
        //TermIdValidator termIdValidator= new TermIdValidator(_errorProvider);
        //textBox.Validating += new CancelEventHandler(termIdValidator.Validate);
    }

    private void CreateLabelControl(string text)
    {
        Label label = new Label();
        label.Text = text;
        label.AutoSize = true;
        _tableLayoutPanel.Controls.Add(label);
    }

    private void CreateListBoxControl(string name)
    {
        ListBox listBox = new ListBox();
        listBox.Width = _controlWidth;
        listBox.Name = "ListBox_PrinterSelection";
        _tableLayoutPanel.Controls.Add(listBox);
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
