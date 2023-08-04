

using MiPowerShell.Handlers.Commands;
using MiPowerShell.Helpers.Common;
using MiPowerShell.Models.WorkstationReport;
using System.ComponentModel;
using System.Windows.Forms;

namespace MiPowerShell.Controls
{
    public partial class WorkstationReportForm : Form
    {
        TabControl _tabControl;
        GetWorkstationReport _getWorkstationReport;

        private BoolWrapper _isHardwareUpdated { get; } = new() { Value = false };
        private BoolWrapper IsMaintenanceUpdated { get; } = new() { Value = false };
        private BoolWrapper _isBiosUpdated { get; } = new() { Value = false };
        private BoolWrapper _isNetworkUpdated { get; } = new() { Value = false };
        private BoolWrapper _isPrintersUpdated { get; } = new() { Value = false };
        private BoolWrapper _isSecurityUpdated { get; } = new() { Value = false };
        private BoolWrapper _isSoftwareUpdated { get; } = new() { Value = false };
        private bool _stopLoop { get; set; } = false;

        public WorkstationReportForm(GetWorkstationReport getWorkstationReport)
        {
            InitializeComponent();
            _getWorkstationReport = getWorkstationReport;
            // Hide the tabs
            _tabControl = mainTabControl;
            mainTabControl.SizeMode = TabSizeMode.Fixed;
            mainTabControl.Appearance = TabAppearance.Buttons;
            mainTabControl.ItemSize = new Size(0, 1);
            mainTabControl.TabStop = false;
            networkNavButton.Enabled = false;
            securityNavButton.Enabled = false;
        }

        private void UpdateTabIfNeeded(BoolWrapper isUpdated, Action updateMethod)
        {
            if (isUpdated.Value) return;

            updateMethod();
            isUpdated.Value = true;
        }

        private async Task InformationCheckAsync(BoolWrapper isInformationInitialized, string? selection)
        {
            Console.WriteLine("Entered Information Check.");
            _stopLoop = false;
            while (!_stopLoop && !isInformationInitialized.Value)
            {
                Console.WriteLine("Information not yet initialized. Delaying...");
                if (selection != null)
                {
                    loadingLabel.Text = $"Loading {selection} ...";
                    loadingLabel.Visible = true;
                }
                await Task.Delay(2000);
            }
            loadingLabel.Text = string.Empty;
            loadingLabel.Visible = false;
            _stopLoop = true;

            Console.WriteLine("Information initialized...");
        }
        private TabPage? GetTabPage(string tabPageName)
        {
            if (_tabControl == null) return null;
            TabPage? tabPage = _tabControl.Controls.OfType<TabPage>().FirstOrDefault(control => control.Name == tabPageName);
            if (tabPage == null) return null;
            return tabPage;
        }

        private string? ConvertTabPageName(TabPage? tabPage)
        {
            if (tabPage == null) return null;
            string tabPageName = tabPage.Name.Replace("TabPage", string.Empty);
            tabPageName = char.ToUpper(tabPageName[0]) + tabPageName.Substring(1);
            return tabPageName;
        }

        private void ChangeTab(TabPage? tabPage)
        {
            if (tabPage == null || _tabControl.SelectedTab == tabPage) return;
            _tabControl.SelectedTab = tabPage;
        }

        private void generalNavButton_Click(object sender, EventArgs e)
        {
            TabPage? tabPage = GetTabPage("generalTabPage");
            ChangeTab(tabPage);
        }

        private async void maintenanceNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsMaintenanceInformationInitialized;
            TabPage? tabPage = GetTabPage("maintenanceTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(IsMaintenanceUpdated, _getWorkstationReport.UpdateMaintenanceTabElements);
            ChangeTab(tabPage);
        }

        private async void hardwareNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsHardwareInformationInitialized;
            TabPage? tabPage = GetTabPage("hardwareTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(_isHardwareUpdated, _getWorkstationReport.UpdateHardwareTabElements);
            ChangeTab(tabPage);
        }

        private async void biosNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsBiosInformationInitialized;
            TabPage? tabPage = GetTabPage("biosTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(_isBiosUpdated, _getWorkstationReport.UpdateBiosTabElements);
            ChangeTab(tabPage);
        }

        private async void networkNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsNetworkInformationInitialized;
            TabPage? tabPage = GetTabPage("networkTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(_isNetworkUpdated, _getWorkstationReport.UpdateNetworkTabElements);
            ChangeTab(tabPage);
        }

        private async void printersNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsPrinterInformationInitialized;
            TabPage? tabPage = GetTabPage("printersTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(_isPrintersUpdated, _getWorkstationReport.UpdatePrinterTabElements);
            ChangeTab(tabPage);
        }

        private async void securityNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsSecurityInformationInitialized;
            TabPage? tabPage = GetTabPage("securityTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            UpdateTabIfNeeded(_isSecurityUpdated, _getWorkstationReport.UpdateSecurityTabElements);
            ChangeTab(tabPage);
        }

        private async void softwareNavButton_Click(object sender, EventArgs e)
        {
            BoolWrapper IsInitialized = _getWorkstationReport.IsSoftwareInformationInitialized;
            TabPage? tabPage = GetTabPage("softwareTabPage");
            string? selection = ConvertTabPageName(tabPage);
            await InformationCheckAsync(IsInitialized, selection);
            //UpdateTabIfNeeded(_isSoftwareUpdated, _getWorkstationReport.UpdateSoftwareTabElements);
            ChangeTab(tabPage);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mainTabControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void printersTabPage_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void printerTable_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
