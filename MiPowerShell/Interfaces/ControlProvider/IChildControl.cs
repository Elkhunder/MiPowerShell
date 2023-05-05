using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Interfaces.ControlProvider
{
    // This interface defines a contract for a child control,
    // specifying that it should provide a method for getting a control by its name.
    public interface IChildControl
    {
        Control GetControlByName(string controlName);
    }
}
