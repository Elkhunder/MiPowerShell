using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Helpers
{
    internal class ControlProviderOld
    {
        public ControlProviderOld() { }

        public static DialogResult GetDialogResult(TableLayoutPanel? parentControl, string controlName)
        {
            // Handle null parent control
            if (parentControl == null)
            {
                return DialogResult.None;
            }

            DialogResult? dialogResult = null;
            // If parent control contains an item with the key name which equals control name
            if ((bool)parentControl?.Controls.ContainsKey(controlName)!)
            {
                dialogResult = ((Button)parentControl.Controls[controlName]!).DialogResult;
            }

            // return dialog result
            return (DialogResult)dialogResult!;
        }

        public static TextBox GetTextBox(TableLayoutPanel? parentControl, string controlName)
        {
            TextBox? textBox= new TextBox();
            if ((bool)parentControl?.Controls.ContainsKey(controlName)!)
            {
                textBox = ((TextBox)parentControl.Controls[controlName]!);
            }
            return textBox;
        }
    }
}
