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
                "Get-UserProfile",
                "Get-WindowsVersion",
                "Remove-UserProfile",
                "Set-BiosPassword",
                "Set-PrinterName",
            };

            DevelopmentCommands = new string[]
            {
                "Uninstall-Software",
                "Set-Printers",
                "Set-NetworkProfile",
                "Install-Language",
                "Get-Printers",
                "Add-Shortcut",
                "Install-Software",
            };
        }
    }
}
