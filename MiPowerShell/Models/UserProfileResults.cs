using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    public class UserProfileResults : CommandResultBase
    {
        public List<string> LocalPath { get; set; }
        public List<bool> Loaded { get; set; }
        public List<string> UserName { get; set; }
        public UserProfileResults()
        {
            LocalPath = new List<string>();
            Loaded = new List<bool>();
            UserName = new List<string>();
        }
    }
}
