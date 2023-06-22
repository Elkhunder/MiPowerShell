using MiPowerShell.Controls.WorkstationReport;

namespace MiPowerShell.Controls
{
    public partial class WorkstationReportForm : Form
    {
        public WorkstationReportForm()
        {
            WorkstationReportControl workstationReportControl = new();
            InitializeComponent();
            this.Controls.Add(workstationReportControl);
        }
    }
}
