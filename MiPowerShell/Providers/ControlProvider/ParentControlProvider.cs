using MiPowerShell.Interfaces.ControlProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Windows.Forms;

namespace MiPowerShell.Providers.ControlProvider
{
    public class ParentControlProvider
    {
        private static FormControlProvider _formControlProvider = FormControlProvider.Instance;

        public static Control GetParentControlByName(string controlName)
        {
            Form form = _formControlProvider.GetForm();
            if (form != null && form.Controls["tableLayoutPanel1"]!.Controls.ContainsKey(controlName))
            {
                return form.Controls["tableLayoutPanel1"]!.Controls[controlName]!;            
            }
            else
            {
                return null;
            }
        }
    }
}
