using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class SoftwareTabElements
    {
        public SoftwareTabElements(TableLayoutPanel softwareTable)
        {
            SoftwareTable = softwareTable;
        }

        public TableLayoutPanel SoftwareTable { get; set; }
    }
}
