using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class BIOSTableElements
    {
        public BIOSTableElements(FlowLayoutPanel biosPanel, FlowLayoutPanel bootOrderPanel, TableLayoutPanel biosSettingsTable)
        {
            BiosPanel = biosPanel;
            BootOrderPanel = bootOrderPanel;
            BiosSettingsTable = biosSettingsTable;
        }

        public FlowLayoutPanel BiosPanel { get; set; }
        public FlowLayoutPanel BootOrderPanel { get; set; }
        public TableLayoutPanel BiosSettingsTable { get; set; }
    }
}
