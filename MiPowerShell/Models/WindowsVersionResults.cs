using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    internal class WindowsVersionResults : CommandResultBase
    {
        public List<string> WindowsVersion { get; set; }
        public WindowsVersionResults()
        {
            WindowsVersion = new List<string>();
        }
    }
}
