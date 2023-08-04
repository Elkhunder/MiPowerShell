using MiPowerShell.Models;
using MiPowerShell.Models.WorkstationReport.Data;

namespace MiPowerShell.Helpers.Managers
{
    internal class ReportManager
    {
        public Form ReportForm;
        private GeneralInformation _generalInformation;

        public ReportManager()
        {
            ReportForm = new Form();
            _generalInformation = new GeneralInformation();
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // Initialize new tab pages
            TabPage generalInformation = new TabPage();
            TabPage maintenanceInformation = new TabPage();
            TabPage hardwareInformation = new TabPage();
            TabPage biosInformation = new TabPage();
            TabPage networkInformation = new TabPage();
            TabPage printersInformation = new TabPage();
            TabPage securityInformation = new TabPage();
            TabPage applicationInformation = new TabPage();

            // Suspend Layouts
            ReportForm.SuspendLayout();
            tabControl.SuspendLayout();

            // Tab page properties
            generalInformation.Name = "General Page";
            generalInformation.Text = "General";
            generalInformation.Dock = DockStyle.Fill;

            maintenanceInformation.Name = "Maintenance Page";
            maintenanceInformation.Text = "Maintenance";
            maintenanceInformation.Dock = DockStyle.Fill;

            hardwareInformation.Name = "Hardware Page";
            hardwareInformation.Text = "Hardware";
            hardwareInformation.Dock = DockStyle.Fill;

            biosInformation.Name = "BIOS Page";
            biosInformation.Text = "BIOS";
            biosInformation.Dock = DockStyle.Fill;

            networkInformation.Name = "Network Page";
            networkInformation.Text = "Network";
            networkInformation.Dock = DockStyle.Fill;

            printersInformation.Name = "Printers Page";
            printersInformation.Text = "Printers";
            printersInformation.Dock = DockStyle.Fill;

            securityInformation.Name = "Security Page";
            securityInformation.Text = "Security";
            securityInformation.Dock = DockStyle.Fill;

            applicationInformation.Name = "Application Page";
            applicationInformation.Text = "Applications";
            applicationInformation.Dock = DockStyle.Fill;

            // Add tab pages to tab control
            tabControl.Controls.Add(generalInformation);
            tabControl.Controls.Add(maintenanceInformation);
            tabControl.Controls.Add(hardwareInformation);
            tabControl.Controls.Add(biosInformation);
            tabControl.Controls.Add(networkInformation);
            tabControl.Controls.Add(printersInformation);
            tabControl.Controls.Add(securityInformation);
            tabControl.Controls.Add(applicationInformation);

            // Form properties
            ReportForm.Controls.Add(tabControl);
            ReportForm.Text = "Workstation Report";
            ReportForm.Width = 600;
            ReportForm.Height = 800;

            // Resume Layouts
            tabControl.ResumeLayout(false);
            ReportForm.ResumeLayout(false);


        }
    }
}
