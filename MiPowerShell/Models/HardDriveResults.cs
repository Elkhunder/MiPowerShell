using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class HardDriveResults : CommandResultBase
    {
        public List<string[]> SerialNumbers { get; set; }
        public HardDriveResults()
        {
            SerialNumbers = new List<string[]>();
        }
    }
}
