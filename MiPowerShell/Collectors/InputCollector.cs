using MiPowerShell.Arguments;
using MiPowerShell.CustomExceptions.FileExceptions;
using MiPowerShell.Dispatchers;
using System.Diagnostics;
using System.Security;

namespace MiPowerShell.Collectors
{
    internal class InputCollector
    {
        private readonly ErrorDispatcher? _errorDispatcher;
        protected readonly Form _form;
        protected readonly TableLayoutPanel? _tableLayoutPanel_Main;
        protected readonly TableLayoutPanel? _tableLayoutPanel_Input;
        protected readonly TableLayoutPanel? _tableLayoutPanel_CommandButtons;
        private static OpenFileDialog? _openFileDialog1;

        public bool RemoteDevice { get; set; }
        public bool LocalDevice { get; set; }
        public InputCollector(Form form)
        {
            _errorDispatcher = new ErrorDispatcher();
            _form = form;

            if (!_form.Controls.ContainsKey("tableLayoutPanel1"))
            {
                throw new Exception("tableLayoutPanel_Input control is not present on the form");
            }
            _tableLayoutPanel_Main = (TableLayoutPanel)_form.Controls["tableLayoutPanel1"]!;

            Debug.WriteLine(_tableLayoutPanel_Main);

            if (!_tableLayoutPanel_Main.Controls.ContainsKey("TableLayoutPanel_Input"))
            {
                throw new Exception("TableLayoutPanel_Input is not present on the form");
            }
            _tableLayoutPanel_Input = (TableLayoutPanel)_tableLayoutPanel_Main.Controls["TableLayoutPanel_Input"]!;
            
            _tableLayoutPanel_CommandButtons = (TableLayoutPanel)_tableLayoutPanel_Main.Controls["TableLayoutPanel_CommandButtons"]!;
        }
        public void AssignOpenFileDialog(OpenFileDialog openFileDialog1)
        {
            _openFileDialog1 = openFileDialog1;
        }
        public CommandArguments Collect()
        {
            var computerNames = CollectComputerNames();
            var oldPrinterName = CollectPrinterName();
            var newPrinterName = CollectNewPrinterName();
            var biosPassword = CollectBiosPassword();
            var newBiosPassword = CollectNewBiosPassword();
            var userName = CollectUserName();
            return new CommandArguments(biosPassword, newBiosPassword, computerNames, oldPrinterName, newPrinterName, userName);
        }

        private string CollectUserName()
        {
            string userName = string.Empty;

            if (_tableLayoutPanel_Input != null && (bool)_tableLayoutPanel_Input.Controls.ContainsKey("TextBox_UserName"))
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["TextBox_UserName"]!).Text;

                if (!string.IsNullOrEmpty(key))
                {
                    userName = key;
                }
                else
                {
                    userName = string.Empty;
                }
            }
            return userName;
        }

        private string CollectNewPrinterName()
        {
            string newPrinterName = string.Empty;
            if (_tableLayoutPanel_Input != null && (bool)_tableLayoutPanel_Input.Controls.ContainsKey("TextBox_NewPrinterName"))
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["TextBox_NewPrinterName"]!).Text;

                if (!string.IsNullOrEmpty(key))
                {
                    newPrinterName = key;
                }
            }
            return newPrinterName;
        }

        private string CollectPrinterName()
        {
            string printerName = "";

            if(_tableLayoutPanel_Input != null && (bool)_tableLayoutPanel_Input.Controls.ContainsKey("ComboBox_PrinterSelection"))
            {
                string key = (string)((ComboBox)_tableLayoutPanel_Input.Controls["ComboBox_PrinterSelection"]!).SelectedItem;

                if (!string.IsNullOrEmpty(key))
                {
                    printerName = key;
                }
                else
                {
                    return null;
                }
            }
            return printerName;
        }

        private SecureString CollectBiosPassword()
        {
            // Collect bios password input
            var biosPassword = new SecureString();

            if (_tableLayoutPanel_Input != null && (bool)_tableLayoutPanel_Input.Controls.ContainsKey("BiosPassword"))
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["BiosPassword"]!).Text;

                if (!string.IsNullOrEmpty(key))
                {
                    foreach (char c in key.ToCharArray())
                    {
                        biosPassword.AppendChar(c);
                    }
                    ((TextBox)_tableLayoutPanel_Input.Controls["BiosPassword"]!).Text = "";
                }
                else
                {
                    return null;
                }    
            }
            return biosPassword;
        }

        private SecureString CollectNewBiosPassword()
        {
            var newBiosPassword = new SecureString();
            if ((bool)_tableLayoutPanel_Input?.Controls.ContainsKey("NewBiosPassword")!)
            {
                string key = ((TextBox)_tableLayoutPanel_Input.Controls["NewBiosPassword"]!).Text;

                if (!string.IsNullOrEmpty(key))
                {
                    foreach (char c in key.ToCharArray())
                    {
                        newBiosPassword.AppendChar(c);
                    }
                    ((TextBox)_tableLayoutPanel_Input.Controls["NewBiosPassword"]!).Text = "";
                }
                else
                {
                    return null;
                }
            }
            return newBiosPassword;
        }

        private string[] CollectComputerNames()
        {
            string? errorSource = null;
            string[] computerNames = new string[0];

            if (LocalDevice)
            {
                computerNames = new string[1];
                computerNames[0] = "localhost";
            }
            if (RemoteDevice)
            {
                if ((bool)_tableLayoutPanel_Input?.Controls.ContainsKey("Computers")!)
                {
                    computerNames = (
                        (TextBox)_tableLayoutPanel_Input.Controls["Computers"]!
                    ).Text.Split(new char[] { ' ', ',' });
                }
                if (_openFileDialog1 != null)
                {
                    string file = _openFileDialog1.FileName;
                    try
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        long maxFileSize = 3000000; // 3MB
                        if (fileInfo.Length > maxFileSize)
                        {
                            errorSource = $"Error Origination: {file}";
                            throw new FileSizeLimitExceededException(
                                $"The file size limit of 3MB was exceeded, {file}"
                            );
                        }

                        string[] allowedExtensions = { "csv", "txt" };

                        if (!allowedExtensions.Contains(Path.GetExtension(file).TrimStart('.')))
                        {
                            errorSource = $"Error Origination: {file}";
                            throw new FileFormatException(
                                $"The provided file didn't have a csv or txt extension, {file}"
                            );
                        }

                        string fileContent = File.ReadAllText(file);

                        if (fileContent.Length == 0)
                        {
                            errorSource = $"Error Origination: {file}";
                            throw new FileEmptyException($"The provided file is empty {file}");
                        }

                        computerNames = fileContent.Split(
                            new char[] { ' ', ',' },
                            StringSplitOptions.RemoveEmptyEntries
                        );
                    }
                    catch (Exception ex)
                    {
                        // TODO: Log the exception for debugging purposes

                        // TODO: pass the exception to the error dispatcher
                        if (errorSource != null)
                        {
                            _errorDispatcher?.Dispatch(ex, errorSource);
                        }
                        else
                        {
                            _errorDispatcher?.Dispatch(ex);
                        }

                    }
                }
            }
            // return computer names
            return computerNames;
        }
    }
}
