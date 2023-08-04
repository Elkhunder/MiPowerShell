using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class HardwareTabElements
    {
        public TableLayoutPanel MainTable;
        public FlowLayoutPanel SystemInformationPanel;
        public TableLayoutPanel ProcessorsTable;
        public TableLayoutPanel MemoryTable;
        public TableLayoutPanel PhysicalDisksTable;
        public TableLayoutPanel LogicalDisksTable;
        public TableLayoutPanel VideoControllersTable;
        public Label ModelLabel;
        public Label ManufacturerLabel;
        public Label SMBIOSAssetTagLabel;
        public Label SerialNumberLabel;
    }
}
