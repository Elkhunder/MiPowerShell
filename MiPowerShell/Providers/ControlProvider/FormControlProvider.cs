using System;
using System.Windows.Forms;

namespace MiPowerShell.Providers.ControlProvider
{
    public sealed class FormControlProvider
    {
        private static FormControlProvider? _instance = null;
        private static readonly object _lock = new object();
        private Form? _form;

        private FormControlProvider() { }

        public static FormControlProvider Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormControlProvider();
                    }
                    return _instance;
                }
            }
        }

        public void SetForm(Form form)
        {
            _form = form;
        }

        public Form GetForm()
        {
            return _form;
        }
    }
}
