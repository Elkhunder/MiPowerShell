using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class CurrentUserResults : CommandResultBase
    {
        public List<string> UserName { get; set; }
        public CurrentUserResults()
        {
            UserName = new List<string>();
        }
    }
}
