using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class SoftwareTabElements
    {
        public SoftwareTabElements(DataGridView softwareDataView)
        {
            SoftwareDataView = softwareDataView;
        }

        public DataGridView SoftwareDataView { get; set; }
    }
}
