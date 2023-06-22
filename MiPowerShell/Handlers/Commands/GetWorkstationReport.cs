using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Models;
using MiPowerShell.Models.WorkstationReport;

namespace MiPowerShell.Handlers.Commands
{
    internal class GetWorkstationReport : ICommandHandler
    {
        private WindowsBuildVersion _windowsBuildVersion = new();

        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            ReportManager reportManager = new();
            Form reportForm = reportManager.ReportForm;
            GeneralInformation generalInformation = new();
            string[] deviceNames = arguments.ComputerNames;

            for (int i = 0; i < deviceNames.Length; i++)
            {
                CimHandler _cimHandler = new(deviceNames[i]);

                string namespaceName = @"root\cimv2";

                CimInstance ComputerSystem = _cimHandler.GetInstances(namespaceName, "Win32_ComputerSystem").FirstOrDefault()!;
                CimInstance OperatingSystem = _cimHandler.GetInstances(namespaceName, "Win32_OperatingSystem").FirstOrDefault()!;
                CimInstance[] NetworkAdapters = _cimHandler.GetInstances(namespaceName, "Win32_NetworkAdapterConfiguration");

                NetworkAdapters = NetworkAdapters.Where(adapter => adapter.CimInstanceProperties["IPAddress"] != null).ToArray();
                
                List<string> ip4Addresses = new List<string>();
                List<string> ip6Addresses = new List<string>();


                for (int j = 0; j < NetworkAdapters.Length; j++)
                {
                    string[] ipAddressesInInstance = NetworkAdapters[j].CimInstanceProperties["IPAddress"].Value as string[];

                    if (ipAddressesInInstance != null)
                    {
                        foreach (string ipAddress in ipAddressesInInstance)
                        {
                            if (ipAddress.Contains(':'))
                            {
                                ip6Addresses.Add(ipAddress);
                            }
                            else
                            {
                                ip4Addresses.Add(ipAddress);
                            }
                            
                        }
                    }
                }
                generalInformation.General.IP4Address = ip4Addresses.ToArray();
                generalInformation.General.IP6Address = ip6Addresses.ToArray();

                TabControl tabControl = reportForm.Controls.OfType<TabControl>().FirstOrDefault()!;
                TabPage generalPage = tabControl.Controls
                    .OfType<TabPage>()
                    .FirstOrDefault(control => control.Name == "General Page")!;
                TabPage maintenancePage = tabControl.Controls
                    .OfType<TabPage>()
                    .FirstOrDefault(control => control.Name == "Maintenance Page")!;

                generalInformation.General.ImageVersion = _windowsBuildVersion.GetVersionByBuildNumber((string)OperatingSystem.CimInstanceProperties["BuildNumber"].Value);
                generalInformation.General.OperatingSystem = (string)OperatingSystem.CimInstanceProperties["Caption"].Value;

                if (!string.IsNullOrEmpty((string)ComputerSystem.CimInstanceProperties["UserName"].Value))
                {
                    generalInformation.General.CurrentUser = (string)ComputerSystem.CimInstanceProperties["UserName"].Value;
                }
                else
                {
                    generalInformation.General.CurrentUser = "None";
                }
                
                FlowLayoutPanel mainFlowLayoutPanel = new FlowLayoutPanel();
                FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
                Button deviceName = new Button();

                deviceName.Enabled = false;
                deviceName.Text = deviceNames[i].ToString().ToUpper();
                deviceName.BackColor = Color.White;
                deviceName.ForeColor = Color.Black;
                deviceName.Font = new Font(deviceName.Font.FontFamily, 15);
                deviceName.TextAlign = ContentAlignment.MiddleCenter;
                //deviceName.Padding = new Padding(5);
                deviceName.AutoSize = true;

                Label ImageVersionLabel = new Label();
                ImageVersionLabel.Text = $"Image Version: {generalInformation.General.ImageVersion}";
                ImageVersionLabel.AutoSize = true;

                Label OperatingSystemLabel = new Label();
                OperatingSystemLabel.Text = $"Operating System: {generalInformation.General.OperatingSystem}";
                OperatingSystemLabel.AutoSize = true;

                Label currentUser = new Label();
                currentUser.Text = $"Current User: {generalInformation.General.CurrentUser}";
                currentUser.AutoSize = true;

                Label ip4AddressLabel = new Label();
                ip4AddressLabel.Text = $"IP4 Address: {string.Join(", ", generalInformation.General.IP4Address)}";
                ip4AddressLabel.AutoSize = true;

                Label ip6AddressLabel = new Label();
                ip6AddressLabel.Text = $"IP6 Address: {string.Join(", ", generalInformation.General.IP6Address)}";
                ip6AddressLabel.AutoSize = true;

                flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanel1.Controls.Add(ImageVersionLabel);
                flowLayoutPanel1.Controls.Add(OperatingSystemLabel);
                flowLayoutPanel1.Controls.Add(currentUser);
                flowLayoutPanel1.Controls.Add(ip4AddressLabel);
                flowLayoutPanel1.Controls.Add(ip6AddressLabel);
                flowLayoutPanel1.AutoSize = true;

                mainFlowLayoutPanel.Dock = DockStyle.Fill;
                mainFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;

                mainFlowLayoutPanel.Controls.Add(deviceName);
                mainFlowLayoutPanel.Controls.Add(flowLayoutPanel1);
                generalPage.Controls.Add(mainFlowLayoutPanel);
                reportForm.Text = $"Windows Report: {deviceNames[i].ToUpper()}";

                reportForm.ShowDialog();
            }
        }
        async Task ShowReportForm(Form reportForm)
        {
            await Task.Delay(100);
            reportForm.ShowDialog();
        }
        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }
    }
}
