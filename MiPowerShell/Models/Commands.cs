using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class Commands
    {
        public string[] ActiveCommands { get; set; }
        public string[] DevelopmentCommands { get; set; }
        public Commands()
        {
            ActiveCommands = new string[]
            {
                "Clear-BiosPassword",
                "Get-CurrentUser",
                "Get-HardDriveSerial",
                "Get-WindowsVersion",
                "Set-BiosPassword",
                "Set-PrinterName"
            };

            DevelopmentCommands = new string[]
            {
                
            };
        }
    }
}
