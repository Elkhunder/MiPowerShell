using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class CommandResultBase
    {
        public List<string> TermID {  get; set; }
        public List<bool>? Successful { get; set; }
        public List<string> Error { get; set; }
        public List<int>? StatusCode { get; set; }

        public CommandResultBase()
        {
            TermID = new List<string>();
            Successful = new List<bool>();
            Error = new List<string>();
            StatusCode = new List<int>();
        }
    }
}
