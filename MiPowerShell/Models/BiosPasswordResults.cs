using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class BiosPasswordResults : CommandResultBase
    {
        public List<bool>? BiosPasswordIsSet { get; set; }

        public BiosPasswordResults() 
        {
            BiosPasswordIsSet = new List<bool>();
        }
    }
}
