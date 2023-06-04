using System;
using System.Windows.Forms;

namespace MiPowerShell.Providers.ControlProvider
{
    public class ChildControlProvider
    {
        public static Control? GetChildControlByName(Control parentControl, string controlName)
        {
            if (parentControl != null && parentControl.Controls.ContainsKey(controlName))
            {
                return parentControl.Controls[controlName]!;
            }
            else
            {
                return null;
            }
        }
    }
}
