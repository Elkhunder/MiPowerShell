using MiPowerShell.Arguments;
using MiPowerShell.CustomExceptions.FileExceptions;
using MiPowerShell.Dispatchers;
using System.Diagnostics;

namespace MiPowerShell.Collectors.CommandInputCollector
{
    internal abstract class InputCollectorBase
    {
        private readonly ErrorDispatcher? _errorDispatcher;
        protected readonly Form _form;
        protected readonly TableLayoutPanel? _tableLayoutPanel_Main;
        protected readonly TableLayoutPanel? _tableLayoutPanel_Input;
        protected readonly TableLayoutPanel? _tableLayoutPanel_CommandButtons;
        private static OpenFileDialog? _openFileDialog1;

        public InputCollectorBase(Form form)
        {
            _errorDispatcher = new ErrorDispatcher();
            _form = form;

            Debug.WriteLine(form.Controls);

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


            _tableLayoutPanel_Input = (TableLayoutPanel)
                _tableLayoutPanel_Main.Controls["TableLayoutPanel_Input"]!;
            _tableLayoutPanel_CommandButtons = (TableLayoutPanel)
                _tableLayoutPanel_Main.Controls["TableLayoutPanel_CommandButtons"]!;
        }

        public static void AssignOpenFileDialog(OpenFileDialog openFileDialog1)
        {
            _openFileDialog1 = openFileDialog1;
        }

        public abstract CommandArguments Collect();

        protected string[] CollectComputerNames()
        {
            DialogResult local = CollectLocal();
            DialogResult remote = CollectRemote();
            string? errorSource = null;
            string[] computerNames = new string[0];

            if (local == DialogResult.Yes)
            {
                computerNames = new string[1];
                computerNames[0] = "localhost";
            }
            if (remote == DialogResult.Yes)
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

        protected DialogResult CollectRemote()
        {
            DialogResult dialogResult = GetButtonDialogResult(_tableLayoutPanel_CommandButtons, "Button_Remote");
            return dialogResult;
        }

        protected DialogResult CollectLocal()
        {
            // get the button dialog result
            DialogResult dialogResult = GetButtonDialogResult(_tableLayoutPanel_CommandButtons, "Button_Local");
            // return the button dialing result
            return dialogResult;
        }

        private DialogResult GetButtonDialogResult(TableLayoutPanel? panel, string buttonName)
        {
            if(panel == null) return DialogResult.None;

            Button? control = panel.Controls.Find(buttonName, true).FirstOrDefault() as Button;

            if(control == null) return DialogResult.None;

            return control.DialogResult;
        }
    }
}
