using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport.Elements
{
    public class MaintenanceTabElements
    {
        public TableLayoutPanel MainTable;
        public FlowLayoutPanel MaintenanceConfigurationPanel;
        public FlowLayoutPanel PowerManagementPanel;
        public Label MaintenanceTime;
        public Label LastBegan;
        public Label LastCompleted;
        public Label LastSucceeded;
        public Label LastResult;
        public Label RebootPending;
        public Label MachineUpTime;
        public Label SystemUnitManagement;
    }
}
