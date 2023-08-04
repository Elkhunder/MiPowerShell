using System.Printing;
using System.ServiceProcess;
using Microsoft.Management.Infrastructure;
using Microsoft.Win32;
using MiPowerShell.Arguments;
using MiPowerShell.Controls;
using MiPowerShell.Controls.WorkstationReport;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Common;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Models;
using MiPowerShell.Models.WorkstationReport.Data;
using MiPowerShell.Models.WorkstationReport.Elements;
using MiPowerShell.Models.WorkstationReport.Enums;
using DriveType = MiPowerShell.Models.WorkstationReport.Enums.DriveType;
using FlowDirection = System.Windows.Forms.FlowDirection;
using Printer = MiPowerShell.Models.WorkstationReport.Data.Printer;

namespace MiPowerShell.Handlers.Commands
{
    public class GetWorkstationReport : ICommandHandler
    {
        private WorkstationReportForm? _reportForm;
        private WindowsBuildVersion _windowsBuildVersion = new();
        private CimHandler? _cimHandler;
        private RegistryManager? _registryManager;
        private PendingReboot? _pendingReboot;

        private TabControl? _tabControl;
        private FlowLayoutPanel? _headerPanel;

        // Tab Pages
        private TabPage? _generalTab;
        private TabPage? _maintenanceTab;
        private TabPage? _hardwareTab;
        private TabPage? _biosTab;
        private TabPage? _networkTab;
        private TabPage? _printersTab;
        private TabPage? _securityTab;
        private TabPage? _softwareTab;

        private CimInstance? _computerSystem;
        private CimInstance? _operatingSystem;
        private CimInstance[]? _networkAdapters;
        private CimInstance[]? _processors;
        private CimInstance[]? _memoryModules;
        private CimInstance[]? _physicalDisks;
        private CimInstance[]? _logicalDisks;
        private CimInstance[]? _videoControllers;
        private CimInstance? _systemEnclosure;
        private Dictionary<string, object>? _departmentRegistry;

        private MaintenanceInformation _maintenanceInformation = new();
        private MaintenanceTabElements _maintenanceElements = new();

        private HardwareTabElements _hardwareElements = new();
        private HardwareInformation _hardwareInformation = new();

        private BIOSInformation? _biosInformation;
        private BIOSTableElements? _biosTableElements;

        private SoftwareInformation _softwareInformation = new();
        private SoftwareTabElements? _softwareTableElements;

        private PrinterInformation? _printerInformation;
        private PrinterTabElements? _printerTabElements;

        public BoolWrapper IsSoftwareInformationInitialized = new() { Value = false };
        public BoolWrapper IsHardwareInformationInitialized = new() { Value = false };
        public BoolWrapper IsNetworkInformationInitialized = new() { Value = false };
        public BoolWrapper IsSecurityInformationInitialized = new() { Value = false };
        public BoolWrapper IsMaintenanceInformationInitialized = new() { Value = false };
        public BoolWrapper IsBiosInformationInitialized = new() { Value = false };
        public BoolWrapper IsPrinterInformationInitialized = new() { Value = false };

        private BackgroundTaskManager TaskManager = new BackgroundTaskManager();
        private PrintServer? _printServer;
        private ServiceController? _serviceController;

        private int _columnIndexOpenPrintQueueButton = 0;
        private int _columnIndexPrinterName = 1;
        private int _columnIndexPrinterDriverName = 2;
        private int _columnIndexPrinterPortName = 3;


        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            _reportForm = new(this);


            GeneralInformation generalInformation = new();
            string[] deviceNames = arguments.ComputerNames;

            for (int i = 0; i < deviceNames.Length; i++)
            {
                InitializeHandlers(deviceNames[i]);

                string namespaceName = @"root\cimv2";
                _computerSystem = GetComputerSystem(namespaceName);
                _operatingSystem = GetOperatingSystem(namespaceName);
                _networkAdapters = GetActiveNetworkAdapters(namespaceName);
                _processors = GetProcessors(namespaceName);
                _physicalDisks = GetHardDrives(namespaceName);
                _logicalDisks = GetLogicalDisks(namespaceName);
                _videoControllers = GetVideoControllers(namespaceName);
                _memoryModules = GetMemoryDevices(namespaceName);
                _systemEnclosure = GetSystemEnclosure(namespaceName);

                _departmentRegistry = GetDepartmentRegistry();

                UpdateGeneralInformationProperties(generalInformation, _computerSystem, _operatingSystem, _departmentRegistry, _networkAdapters);
                TableLayoutPanel tableLayoutPanel = GetTableLayoutPanel(_reportForm, "mainTableLayoutPanel");

                _tabControl = GetTabControl(tableLayoutPanel, "mainTabControl");
                _headerPanel = GetHeaderPanel(tableLayoutPanel, "headerFlowLayoutPanel");

                HeaderPanelElements headerElements = GetHeaderPanelElements(_headerPanel);
                UpdateHeaderPanelElements(headerElements, generalInformation);

                TabPage generalTabPage = FindControl<TabPage>(_tabControl, "generalTabPage");

                GeneralTabElements generalElements = GetGeneralTabElements(generalTabPage);
                UpdateGeneralTabElements(generalElements, generalInformation);

                _reportForm.Show();

                UpdateRemainingProperties(_computerSystem.CimInstanceProperties["Caption"].Value.ToString()?.ToUpper());
            }
        }
        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }

        private async void UpdateRemainingProperties(string deviceName)
        {
            if (_tabControl != null)
            {
                foreach (TabPage tabPage in _tabControl.Controls)
                {
                    Console.WriteLine(tabPage.Name);
                    switch (tabPage.Name)
                    {
                        case "maintenanceTabPage":
                            await TaskManager.RunTask(() =>
                            {
                                GetMaintenanceTabElements(tabPage);
                                UpdateMaintenanceProperties(_maintenanceInformation, _departmentRegistry, _operatingSystem);
                            });
                            break;
                        case "hardwareTabPage":
                            await TaskManager.RunTask(() =>
                            {
                                GetHardwareTabElements(tabPage);
                                UpdateHardwareProperties(_computerSystem, _processors, _physicalDisks, _logicalDisks, _memoryModules, _videoControllers, _systemEnclosure);
                            });
                            break;
                        case "biosTabPage":
                            await TaskManager.RunTask(() =>
                            {
                                GetBiosTabElements(tabPage);
                                UpdateBiosProperties();
                            });
                            break;
                        //case "networkTabPage":
                        //    GetNetworkTabElements(tabPage);
                        //    UpdateNetworkProperties();
                        //    break;
                        case "printersTabPage":
                            await TaskManager.RunTask(async () =>
                            {
                                GetPrintersTabElements(tabPage);
                                var printers = await GetPrintersAsync(@"root\cimv2");
                                UpdatePrinterProperties(_reportForm, printers, GetDefaultPrinter(), deviceName);
                            });
                            break;
                        //case "securityTabPage":
                        //    GetSecurityTabElements(tabPage);
                        //    UpdateSecurityProperties();
                        //    break;
                        case "softwareTabPage":
                            await TaskManager.RunTask(() =>
                            {
                                GetSoftwareTabElements(tabPage);
                                UpdateSoftwareProperties();
                            });
                            break;
                    }
                }
            }
        }



        private static TableLayoutPanel GetTableLayoutPanel(WorkstationReportForm reportForm, string controlName)
        {
            return reportForm.Controls
                             .OfType<TableLayoutPanel>()
                             .FirstOrDefault(control => control.Name == controlName)!;
        }
        private static TabControl GetTabControl(TableLayoutPanel tableLayoutPanel, string controlName)
        {
            return tableLayoutPanel.Controls
                                   .OfType<TabControl>()
                                   .FirstOrDefault(control => control.Name == controlName)!;
        }


        // Header Panel Methods
        private static FlowLayoutPanel GetHeaderPanel(TableLayoutPanel tableLayoutPanel, string controlName)
        {
            return tableLayoutPanel.Controls
                                   .OfType<FlowLayoutPanel>()
                                   .FirstOrDefault(control => control.Name == controlName)!;
        }
        private static HeaderPanelElements GetHeaderPanelElements(FlowLayoutPanel headerPanel)
        {
            HeaderPanelElements elements = new HeaderPanelElements();
            if (headerPanel != null)
            {
                SetField(ref elements.DeviceNameLabel, FindControl<Label>(headerPanel, "deviceNameHeaderLabel"));
                SetField(ref elements.IPAddressLabel, FindControl<Label>(headerPanel, "ipAddressHeaderLabel"));
                SetField(ref elements.ImageVersionLabel, FindControl<Label>(headerPanel, "imageVersionHeaderLabel"));
                SetField(ref elements.ImageModeLabel, FindControl<Label>(headerPanel, "imageModeHeaderLabel"));
                SetField(ref elements.CurrentUserLabel, FindControl<Label>(headerPanel, "currentUserHeaderLabel"));
            }
            return elements;
        }
        private static void UpdateHeaderPanelElements(HeaderPanelElements elements, GeneralInformation generalInformation)
        {
            elements.ImageVersionLabel.Text = $"Image Version: {generalInformation.General.ImageVersion}";
            elements.ImageModeLabel.Text = $"Mode: {generalInformation.General.ImageMode}";
            elements.CurrentUserLabel.Text = $"Current User: {generalInformation.General.CurrentUser}";
            elements.DeviceNameLabel.Text = generalInformation.General.DeviceName;
            elements.IPAddressLabel.Text = $"IP4 Address: {generalInformation.General?.IP4Address?[0]}";
        }


        // General Methods
        private GeneralTabElements GetGeneralTabElements(TabPage tabPage)
        {
            _generalTab = tabPage;

            GeneralTabElements elements = new GeneralTabElements();

            TableLayoutPanel generalTable = tabPage.Controls
                .OfType<TableLayoutPanel>()
                .FirstOrDefault(control => control.Name == "generalTableLayoutPanel")!;

            FlowLayoutPanel generalPanel = generalTable.Controls
                .OfType<FlowLayoutPanel>()
                .FirstOrDefault(control => control.Name == "generalInformationFlowLayoutPanel")!;

            SetField(ref elements.OperatingSystemLabel, FindControl<Label>(generalPanel, "operatingSystemLabel"));
            SetField(ref elements.ImageVersionLabel, FindControl<Label>(generalPanel, "imageVersionLabel"));
            SetField(ref elements.ImageModeLabel, FindControl<Label>(generalPanel, "imageModeLabel"));
            SetField(ref elements.CurrentUserLabel, FindControl<Label>(generalPanel, "currentUserLabel"));

            FlowLayoutPanel screenPanel = generalTable.Controls
                .OfType<FlowLayoutPanel>()
                .FirstOrDefault(control => control.Name == "screenTimeoutFlowLayoutPanel")!;

            SetField(ref elements.ScreenSaverTimeoutLabel, FindControl<Label>(screenPanel, "screenSaverTimeoutLabel"));
            SetField(ref elements.ScreenLockTimeoutLabel, FindControl<Label>(screenPanel, "screenLockTimeoutLabel"));
            SetField(ref elements.AutoLogoffTimeoutLabel, FindControl<Label>(screenPanel, "autoLogoffTimeoutLabel"));

            FlowLayoutPanel centricityPanel = generalTable.Controls
                .OfType<FlowLayoutPanel>()
                .FirstOrDefault(control => control.Name == "centricityFlowLayoutPanel")!;

            SetField(ref elements.CentricityTimerLabel, FindControl<Label>(centricityPanel, "centricityTimerLabel"));
            SetField(ref elements.CentricityEnvironmentLabel, FindControl<Label>(centricityPanel, "centricityEnvironmentLabel"));

            // FlowLayoutPanel buildPanel = generalTable.Controls
            //     .OfType<FlowLayoutPanel>()
            //     .FirstOrDefault(control => control.Name == "buildInformationFlowLayoutPanel")!;
            SetField(ref elements.BuildPanel, FindControl<FlowLayoutPanel>(generalTable, "buildInformationFlowLayoutPanel"));

            SetField(ref elements.BuiltByLabel, FindControl<Label>(elements.BuildPanel, "builtByLabel"));
            SetField(ref elements.BuildDateLabel, FindControl<Label>(elements.BuildPanel, "buildDateLabel"));

            return elements;
        }
        private void UpdateGeneralInformationProperties(GeneralInformation generalInformation, CimInstance ComputerSystem, CimInstance OperatingSystem, Dictionary<string, object>? departmentRegistry, CimInstance[]? NetworkAdapters)
        {
            List<string> ip4Addresses = new List<string>();
            List<string> ip6Addresses = new List<string>();
            if (NetworkAdapters != null && NetworkAdapters.Length > 0)
            {
                for (int i = 0; i < NetworkAdapters.Length; i++)
                {
                    if (NetworkAdapters[i].CimInstanceProperties["IPAddress"].Value is string[] ipAddressesInInstance)
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
            }
            string[] securityTimers = Array.Empty<string>();
            if (departmentRegistry != null)
            {
                securityTimers = departmentRegistry.TryGetValue("Timers", out var timers) ? timers.ToString().Substring(1).Split('.') : new string[] { "Not Found", "Not Found" };
                generalInformation.General.ImageMode = departmentRegistry.TryGetValue("MODE", out var modeValue) ? (string)modeValue : "Not Found";

                generalInformation.BuildInformation.BuiltBy = departmentRegistry.TryGetValue("BuiltBy", out var builtByValue) ? (string)builtByValue : "Not Found";
                generalInformation.BuildInformation.BuildDate = departmentRegistry.TryGetValue("BuildDate", out var buildDateValue) ? (string)buildDateValue : "Not Found";

                generalInformation.Centricity.Timer = departmentRegistry.TryGetValue("CenTimer", out var cenTimerValue) ? (string)cenTimerValue : "Not Found";
                generalInformation.Centricity.Environment = departmentRegistry.TryGetValue("CenEnv", out var cenEnvValue) ? (string)cenEnvValue : "Not Found";
            }


            generalInformation.General.IP4Address = ip4Addresses.ToArray();
            generalInformation.General.IP6Address = ip6Addresses.ToArray();
            generalInformation.General.DeviceName = ComputerSystem.CimInstanceProperties["Caption"].Value.ToString()?.ToUpper();

            generalInformation.General.ImageVersion = _windowsBuildVersion.GetVersionByBuildNumber((string)OperatingSystem.CimInstanceProperties["BuildNumber"].Value);
            generalInformation.General.OperatingSystem = (string)OperatingSystem.CimInstanceProperties["Caption"].Value;
            generalInformation.General.CurrentUser = string.IsNullOrEmpty((string)ComputerSystem.CimInstanceProperties["UserName"].Value) ? "None" : (string)ComputerSystem.CimInstanceProperties["UserName"].Value;

            generalInformation.ScreenTimeOuts.ScreenSaverTimeout = $"00:{securityTimers[0]}:00";
            generalInformation.ScreenTimeOuts.ScreenLockTimeout = $"00:{securityTimers[1]}:000";
        }
        private static void UpdateGeneralTabElements(GeneralTabElements elements, GeneralInformation generalInformation)
        {
            elements.OperatingSystemLabel.Text = $"Operating System:  {generalInformation.General.OperatingSystem}";
            elements.ImageVersionLabel.Text = $"Image Version:  {generalInformation.General.ImageVersion}";
            elements.ImageModeLabel.Text = $"Mode:  {generalInformation.General.ImageMode}";
            elements.CurrentUserLabel.Text = $"Current User:  {generalInformation.General.CurrentUser}";
            elements.ScreenSaverTimeoutLabel.Text = $"Screen Saver Timeout:  {generalInformation.ScreenTimeOuts.ScreenSaverTimeout}";
            elements.ScreenLockTimeoutLabel.Text = $"Screen Lock Timeout:  {generalInformation.ScreenTimeOuts.ScreenLockTimeout}";
            elements.AutoLogoffTimeoutLabel.Text = $"Auto Logoff Timeout:  {generalInformation.ScreenTimeOuts.AutoLogoffTimeout}";
            elements.CentricityTimerLabel.Text = $"Timer:  {generalInformation.Centricity.Timer}";
            elements.CentricityEnvironmentLabel.Text = $"Environment:  {generalInformation.Centricity.Environment}";
            elements.BuiltByLabel.Text = $"Built By:  {generalInformation.BuildInformation.BuiltBy}";
            elements.BuildDateLabel.Text = $"Build Date:  {generalInformation.BuildInformation.BuildDate}";
        }


        // Maintenance Methods
        private MaintenanceTabElements GetMaintenanceTabElements(TabPage tabPage)
        {
            _maintenanceTab = tabPage;
            SetField(ref _maintenanceElements.MainTable, FindControl<TableLayoutPanel>(tabPage, "maintenanceTableLayoutPanel"));
            SetField(ref _maintenanceElements.MaintenanceConfigurationPanel, FindControl<FlowLayoutPanel>(_maintenanceElements.MainTable, "maintenanceConfigurationFlowLayoutPanel"));
            SetField(ref _maintenanceElements.PowerManagementPanel, FindControl<FlowLayoutPanel>(_maintenanceElements.MainTable, "powerManagementFlowLayoutPanel"));

            SetField(ref _maintenanceElements.MaintenanceTime, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "maintenanceTimeLabel"));
            SetField(ref _maintenanceElements.LastBegan, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "lastBeganLabel"));
            SetField(ref _maintenanceElements.LastCompleted, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "lastCompletedLabel"));
            SetField(ref _maintenanceElements.LastSucceeded, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "lastSucceededLabel"));
            SetField(ref _maintenanceElements.LastResult, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "lastResultLabel"));
            SetField(ref _maintenanceElements.RebootPending, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "rebootPendingLabel"));
            SetField(ref _maintenanceElements.MachineUpTime, FindControl<Label>(_maintenanceElements.MaintenanceConfigurationPanel, "machineUpTimeLabel"));
            SetField(ref _maintenanceElements.SystemUnitManagement, FindControl<Label>(_maintenanceElements.PowerManagementPanel, "systemUnitManagementLabel"));

            return _maintenanceElements;
        }
        private void UpdateMaintenanceProperties(MaintenanceInformation maintenanceInformation, Dictionary<string, object> departmentRegistry, CimInstance operatingSystem)
        {
            bool? IsPendingReboot = _pendingReboot?.RunTests();
            if (departmentRegistry != null)
            {
                maintenanceInformation.Configuration.MaintenanceTime = departmentRegistry.TryGetValue("MaintTime", out var maintTime) ? (string)maintTime : "Not Found";
                maintenanceInformation.Configuration.LastBegan = departmentRegistry.TryGetValue("MaintLastBegin", out var maintLastBegin) ? (string)maintLastBegin : "Not Found";
                maintenanceInformation.Configuration.LastCompleted = departmentRegistry.TryGetValue("MaintLastFinish", out var maintLastFinish) ? (string)maintLastFinish : "Not Found";
                maintenanceInformation.Configuration.LastSucceeded = departmentRegistry.TryGetValue("MaintLastSuccess", out var maintLastSuccess) ? (string)maintLastSuccess : "Not Found";
                maintenanceInformation.Configuration.LastResult = departmentRegistry.TryGetValue("MaintLastStatus", out var maintLastStatus) ? (string)maintLastStatus : "Not Found";
            }
            if (operatingSystem != null)
            {
                DateTime lastBootUp = (DateTime)operatingSystem.CimInstanceProperties["LastBootUpTime"].Value;
                TimeSpan uptime = DateTime.Now - lastBootUp;
                maintenanceInformation.Configuration.MachineUpTime = $"Days: {uptime.Days}, Hours: {uptime.Hours}, Minutes: {uptime.Minutes}, Seconds: {uptime.Seconds}";
            }
            maintenanceInformation.Configuration.RebootPending = IsPendingReboot;
            maintenanceInformation.PowerManagement.SystemUnitManagement = "Not Managed";

            IsMaintenanceInformationInitialized.Value = true;
        }
        public void UpdateMaintenanceTabElements()
        {
            PrintServer printServer = new PrintServer();
            if (this._maintenanceInformation != null)
            {
                _maintenanceElements.MaintenanceTime.Text = $"Maintenance Time:  {_maintenanceInformation.Configuration.MaintenanceTime}";
                _maintenanceElements.LastBegan.Text = $"Last Began:  {_maintenanceInformation.Configuration.LastBegan}";
                _maintenanceElements.LastCompleted.Text = $"Last Completed:  {_maintenanceInformation.Configuration.LastCompleted}";
                _maintenanceElements.LastSucceeded.Text = $"Last Succeeded:  {_maintenanceInformation.Configuration.LastSucceeded}";
                _maintenanceElements.LastResult.Text = $"Last Result:  {_maintenanceInformation.Configuration.LastResult}";
                _maintenanceElements.RebootPending.Text = $"Reboot Pending:  {_maintenanceInformation.Configuration.RebootPending}";
                _maintenanceElements.MachineUpTime.Text = $"Machine Up Time:  {_maintenanceInformation.Configuration.MachineUpTime}";
                _maintenanceElements.SystemUnitManagement.Text = $"System Unit Management:  {_maintenanceInformation.PowerManagement.SystemUnitManagement}";
            }
        }


        // Hardware Methods
        private HardwareTabElements GetHardwareTabElements(TabPage tabPage)
        {
            _hardwareTab = tabPage;

            SetField(ref _hardwareElements.MainTable, FindControl<TableLayoutPanel>(tabPage, "hardwareTableLayoutPanel"));

            TableLayoutPanel mainTable = _hardwareElements.MainTable;

            SetField(ref _hardwareElements.SystemInformationPanel, FindControl<FlowLayoutPanel>(mainTable, "systemInformationPanel"));
            SetField(ref _hardwareElements.ProcessorsTable, FindControl<TableLayoutPanel>(mainTable, "hardwareProcessorsTable"));
            SetField(ref _hardwareElements.MemoryTable, FindControl<TableLayoutPanel>(mainTable, "hardwareMemoryTable"));
            SetField(ref _hardwareElements.PhysicalDisksTable, FindControl<TableLayoutPanel>(mainTable, "hardwarePhysicalDisksTable"));
            SetField(ref _hardwareElements.LogicalDisksTable, FindControl<TableLayoutPanel>(mainTable, "hardwareLogicalDisksTable"));
            SetField(ref _hardwareElements.VideoControllersTable, FindControl<TableLayoutPanel>(mainTable, "hardwareVideoContollersTable"));

            FlowLayoutPanel systemPanel = _hardwareElements.SystemInformationPanel;

            SetField(ref _hardwareElements.ModelLabel, FindControl<Label>(systemPanel, "modelLabel"));
            SetField(ref _hardwareElements.ManufacturerLabel, FindControl<Label>(systemPanel, "manufacturerLabel"));
            SetField(ref _hardwareElements.SMBIOSAssetTagLabel, FindControl<Label>(systemPanel, "SMBIOSAssetTagLabel"));
            SetField(ref _hardwareElements.SerialNumberLabel, FindControl<Label>(systemPanel, "serialNumberLabel"));

            return _hardwareElements;
        }
        private void UpdateHardwareProperties(CimInstance computerSystem, CimInstance[] processors, CimInstance[] physicalDisks, CimInstance[] logicalDisks, CimInstance[] memoryModules, CimInstance[] videoControllers, CimInstance systemEnclosure)
        {
            _hardwareInformation.SystemInformation.Model = (string)computerSystem.CimInstanceProperties["Model"].Value;
            _hardwareInformation.SystemInformation.Manufacturer = (string)computerSystem.CimInstanceProperties["Manufacturer"].Value;
            _hardwareInformation.SystemInformation.SMBIOSAssetTag = (string)systemEnclosure.CimInstanceProperties["SMBIOSAssetTag"].Value;
            _hardwareInformation.SystemInformation.SerialNumber = (string)systemEnclosure.CimInstanceProperties["SerialNumber"].Value;

            foreach (CimInstance processor in processors)
            {
                _hardwareInformation.Processors.Add(
                new Processor
                {
                    Name = (string)processor.CimInstanceProperties["Name"].Value,
                    Architecture = ((Architecture)(UInt16)processor.CimInstanceProperties["Architecture"].Value),
                    ProcessorType = ((ProcessorType)(UInt16)processor.CimInstanceProperties["ProcessorType"].Value),
                    CPUStatus = ((CpuStatus)(UInt16)processor.CimInstanceProperties["CPUStatus"].Value),
                });
            }

            foreach (CimInstance disk in physicalDisks)
            {
                _hardwareInformation.PhysicalDisks.Add(
                new PhysicalDisk
                {
                    Name = (string)disk.CimInstanceProperties["Name"].Value,
                    Model = (string)disk.CimInstanceProperties["Model"].Value,
                    Partitions = (UInt32)disk.CimInstanceProperties["Partitions"].Value,
                    Size = (UInt64)disk.CimInstanceProperties["Size"].Value,
                    InterfaceType = (string)disk.CimInstanceProperties["InterfaceType"].Value,
                    MediaType = (string)disk.CimInstanceProperties["MediaType"].Value,
                });
            }

            foreach (CimInstance disk in logicalDisks)
            {
                var logicalDisk = new LogicalDisk();
                if (disk.CimInstanceProperties["VolumeName"].Value != null)
                {
                    logicalDisk.Name = (string)disk.CimInstanceProperties["VolumeName"].Value;
                }
                if (disk.CimInstanceProperties["Size"].Value != null)
                {
                    logicalDisk.Size = (UInt64)disk.CimInstanceProperties["Size"].Value;
                }
                if (disk.CimInstanceProperties["DeviceID"].Value != null)
                {
                    logicalDisk.DeviceID = (string)disk.CimInstanceProperties["DeviceID"].Value;
                }
                if (disk.CimInstanceProperties["FileSystem"].Value != null)
                {
                    logicalDisk.FileSystem = (string)disk.CimInstanceProperties["FileSystem"].Value;
                }
                if (disk.CimInstanceProperties["FreeSpace"].Value != null)
                {
                    logicalDisk.FreeSpace = (UInt64)disk.CimInstanceProperties["FreeSpace"].Value;
                }
                if (disk.CimInstanceProperties["DriveType"].Value != null)
                {
                    logicalDisk.DriveType = ((DriveType)(UInt32)disk.CimInstanceProperties["DriveType"].Value);
                }
                _hardwareInformation.LogicalDisks.Add(logicalDisk);
            }

            foreach (CimInstance module in memoryModules)
            {
                _hardwareInformation.MemoryModules.Add(
                    new MemoryModule
                    {
                        Name = (string)module.CimInstanceProperties["Name"].Value,
                        Capacity = (UInt64)module.CimInstanceProperties["Capacity"].Value,
                        Speed = (UInt32)module.CimInstanceProperties["Speed"].Value,
                        Type = ((TypeDetail)(UInt16)module.CimInstanceProperties["TypeDetail"].Value),
                    });
            }

            foreach (CimInstance controller in videoControllers)
            {
                var adapterRam = controller.CimInstanceProperties["AdapterRAM"]?.Value;
                var currentBitsPerPixel = controller.CimInstanceProperties["CurrentBitsPerPixel"]?.Value;
                var videoProcessor = controller.CimInstanceProperties["VideoController"]?.Value;
                if (adapterRam != null && currentBitsPerPixel != null && videoProcessor != null)
                {
                    _hardwareInformation.VideoControllers.Add(new VideoController
                    {
                        Name = (string)controller.CimInstanceProperties["Name"].Value,
                        AdapterRAM = (UInt32)controller.CimInstanceProperties["AdapterRAM"].Value,
                        CurrentBitsPerPixel = (UInt32)controller.CimInstanceProperties["CurrentBitsPerPixel"].Value,
                        DriverVersion = (string)controller.CimInstanceProperties["DriverVersion"].Value,
                        DriverDate = (DateTime)controller.CimInstanceProperties["DriverDate"].Value,
                        VideoProcessor = (string)controller.CimInstanceProperties["VideoProcessor"].Value
                    });
                }
                else
                {
                    _hardwareInformation.VideoControllers.Add(new VideoController
                    {
                        Name = (string)controller.CimInstanceProperties["Name"].Value,
                        DriverVersion = (string)controller.CimInstanceProperties["DriverVersion"].Value,
                        DriverDate = (DateTime)controller.CimInstanceProperties["DriverDate"].Value,
                    });
                }
            }
            IsHardwareInformationInitialized.Value = true;

        }
        public void UpdateHardwareTabElements()
        {
            _hardwareElements.ModelLabel.Text = $"Model:  {_hardwareInformation.SystemInformation.Model}";
            _hardwareElements.ManufacturerLabel.Text = $"Manufacturer:  {_hardwareInformation.SystemInformation.Manufacturer}";
            _hardwareElements.SMBIOSAssetTagLabel.Text = $"Asset Tag:  {_hardwareInformation.SystemInformation.SMBIOSAssetTag}";
            _hardwareElements.SerialNumberLabel.Text = $"Serial Number:  {_hardwareInformation.SystemInformation.SerialNumber}";

            foreach (Processor processor in _hardwareInformation.Processors)
            {
                int rowIndex = _hardwareElements.ProcessorsTable.RowCount++;

                _hardwareElements.ProcessorsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label nameLabel = new Label() { Text = processor.Name, AutoSize = true };
                Label processorTypeLabel = new Label() { Text = processor.ProcessorType.ToString(), AutoSize = true };
                Label architectureLabel = new Label() { Text = processor.Architecture.ToString(), AutoSize = true };
                Label cpuStatusLabel = new Label() { Text = processor.CPUStatus.ToString(), AutoSize = true };

                _hardwareElements.ProcessorsTable.Controls.Add(nameLabel, 0, rowIndex);
                _hardwareElements.ProcessorsTable.Controls.Add(processorTypeLabel, 1, rowIndex);
                _hardwareElements.ProcessorsTable.Controls.Add(architectureLabel, 2, rowIndex);
                _hardwareElements.ProcessorsTable.Controls.Add(cpuStatusLabel, 3, rowIndex);
            }

            foreach (MemoryModule module in _hardwareInformation.MemoryModules)
            {
                int rowIndex = _hardwareElements.MemoryTable.RowCount++;

                _hardwareElements.MemoryTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label nameLabel = new Label() { Text = module.Name, AutoSize = true };
                Label capacityLabel = new Label() { Text = module.Capacity.ToString(), AutoSize = true };
                Label speedLabel = new Label() { Text = module.Speed.ToString(), AutoSize = true };
                Label typeLabel = new Label() { Text = module.Type.ToString(), AutoSize = true };

                _hardwareElements.MemoryTable.Controls.Add(nameLabel, 0, rowIndex);
                _hardwareElements.MemoryTable.Controls.Add(capacityLabel, 1, rowIndex);
                _hardwareElements.MemoryTable.Controls.Add(speedLabel, 2, rowIndex);
                _hardwareElements.MemoryTable.Controls.Add(typeLabel, 3, rowIndex);
            }

            foreach (PhysicalDisk drive in _hardwareInformation.PhysicalDisks)
            {
                int rowIndex = _hardwareElements.PhysicalDisksTable.RowCount++;

                _hardwareElements.PhysicalDisksTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label nameLabel = new Label() { Text = drive.Name, AutoSize = true };
                Label modelLabel = new Label() { Text = drive.Model, AutoSize = true };
                Label sizeLabel = new Label() { Text = drive.Size.ToString(), AutoSize = true };
                Label interfaceLabel = new Label() { Text = drive.InterfaceType, AutoSize = true };
                Label mediaTypeLabel = new Label() { Text = drive.MediaType, AutoSize = true };
                Label partitionsLabel = new Label() { Text = drive.Partitions.ToString(), AutoSize = true };

                _hardwareElements.PhysicalDisksTable.Controls.Add(nameLabel, 0, rowIndex);
                _hardwareElements.PhysicalDisksTable.Controls.Add(modelLabel, 1, rowIndex);
                _hardwareElements.PhysicalDisksTable.Controls.Add(sizeLabel, 2, rowIndex);
                _hardwareElements.PhysicalDisksTable.Controls.Add(interfaceLabel, 3, rowIndex);
                _hardwareElements.PhysicalDisksTable.Controls.Add(mediaTypeLabel, 4, rowIndex);
                _hardwareElements.PhysicalDisksTable.Controls.Add(partitionsLabel, 5, rowIndex);
            }

            foreach (LogicalDisk disk in _hardwareInformation.LogicalDisks)
            {
                int rowIndex = _hardwareElements.LogicalDisksTable.RowCount++;

                _hardwareElements.LogicalDisksTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label deviceIdLabel = new Label() { Text = disk.DeviceID, AutoSize = true };
                Label nameLabel = new Label() { Text = disk.Name, AutoSize = true };
                Label fileSystemLabel = new Label() { Text = disk.FileSystem, AutoSize = true };
                Label driveTypeLabel = new Label() { Text = disk.DriveType.ToString(), AutoSize = true };
                Label freeSpaceLabel = new Label() { Text = disk.FreeSpace.ToString(), AutoSize = true };
                Label sizeLabel = new Label() { Text = disk.Size.ToString(), AutoSize = true };

                _hardwareElements.LogicalDisksTable.Controls.Add(deviceIdLabel, 0, rowIndex);
                _hardwareElements.LogicalDisksTable.Controls.Add(nameLabel, 1, rowIndex);
                _hardwareElements.LogicalDisksTable.Controls.Add(fileSystemLabel, 2, rowIndex);
                _hardwareElements.LogicalDisksTable.Controls.Add(driveTypeLabel, 3, rowIndex);
                _hardwareElements.LogicalDisksTable.Controls.Add(freeSpaceLabel, 4, rowIndex);
                _hardwareElements.LogicalDisksTable.Controls.Add(sizeLabel, 5, rowIndex);
            }

            foreach (VideoController controller in _hardwareInformation.VideoControllers)
            {
                int rowIndex = _hardwareElements.VideoControllersTable.RowCount++;

                _hardwareElements.VideoControllersTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label nameLabel = new Label() { Text = controller.Name, AutoSize = true };
                Label adapterRAMLabel = new Label() { Text = controller.AdapterRAM.ToString(), AutoSize = true };
                Label currentBitsPerPixelLabel = new Label() { Text = controller.CurrentBitsPerPixel.ToString(), AutoSize = true };
                Label driverVersionLabel = new Label() { Text = controller.DriverVersion, AutoSize = true };
                Label driverDateLabel = new Label() { Text = controller.DriverDate.ToShortDateString(), AutoSize = true };
                Label videoProcessorLabel = new Label() { Text = controller.VideoProcessor, AutoSize = true };

                _hardwareElements.VideoControllersTable.Controls.Add(nameLabel, 0, rowIndex);
                _hardwareElements.VideoControllersTable.Controls.Add(adapterRAMLabel, 1, rowIndex);
                _hardwareElements.VideoControllersTable.Controls.Add(currentBitsPerPixelLabel, 2, rowIndex);
                _hardwareElements.VideoControllersTable.Controls.Add(driverVersionLabel, 3, rowIndex);
                _hardwareElements.VideoControllersTable.Controls.Add(driverDateLabel, 4, rowIndex);
                _hardwareElements.VideoControllersTable.Controls.Add(videoProcessorLabel, 5, rowIndex);
            }
        }


        // BIOS Methods
        private void GetBiosTabElements(TabPage tabPage)
        {
            _biosTab = tabPage;
            TableLayoutPanel biosTable = FindControl<TableLayoutPanel>(tabPage, "biosTable");
            FlowLayoutPanel biosPanel = FindControl<FlowLayoutPanel>(biosTable, "biosInformationPanel");
            FlowLayoutPanel bootOrderPanel = FindControl<FlowLayoutPanel>(biosTable, "bootOrderPanel");
            TableLayoutPanel biosSettingsTable = FindControl<TableLayoutPanel>(biosTable, "biosSettingsTable");
            _biosTableElements = new BIOSTableElements(biosPanel, bootOrderPanel, biosSettingsTable);
        }
        private void UpdateBiosProperties()
        {
            IEnumerable<string>? bootOrder = GetBootOrder();
            List<BIOSSetting> biosSettings = GetBIOSSettings();
            Dictionary<string, object>? bios = GetBiosRegistryHive();
            if (bootOrder != null && bios != null)
            {
                bios.TryGetValue("SystemProductName", out var systemModel);
                bios.TryGetValue("BIOSVersion", out var biosVersion);
                bios.TryGetValue("BIOSReleaseDate", out var biosDate);
                if (systemModel is string systemModelString && biosVersion is string biosVersionString && biosDate is string biosDateString)
                {
                    _biosInformation = new BIOSInformation(systemModelString, biosVersionString, biosDateString, bootOrder, biosSettings);
                }
            }
            IsBiosInformationInitialized.Value = true;
        }
        public void UpdateBiosTabElements()
        {
            if (_biosInformation != null && _biosTableElements != null)
            {
                Label model = new Label();
                model.Text = $"System Model:  {_biosInformation.SystemModel}";
                model.AutoSize = true;

                Label biosVersion = new Label();
                biosVersion.Text = $"BIOS Version:  {_biosInformation.BIOSVersion}";
                biosVersion.AutoSize = true;

                Label biosDate = new Label();
                biosDate.Text = $"BIOS Date:  {_biosInformation.BIOSDate}";
                biosDate.AutoSize = true;

                _biosTableElements.BiosPanel.FlowDirection = FlowDirection.TopDown;
                _biosTableElements.BiosPanel.Controls.Add(model);
                _biosTableElements.BiosPanel.Controls.Add(biosVersion);
                _biosTableElements.BiosPanel.Controls.Add(biosDate);

                int i = 1;
                foreach (string bootDevice in _biosInformation.BootOrder)
                {
                    Label label = new Label();
                    label.Text = $"{i}:  {bootDevice}";
                    label.AutoSize = true;

                    _biosTableElements.BootOrderPanel.FlowDirection = FlowDirection.TopDown;
                    _biosTableElements.BootOrderPanel.Controls.Add(label);

                    i++;
                }
                foreach (BIOSSetting setting in _biosInformation.BIOSSettings)
                {
                    int rowIndex = _biosTableElements.BiosSettingsTable.RowCount++;
                    _biosTableElements.BiosSettingsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    Label attributeName = new Label();
                    attributeName.AutoSize = true;
                    attributeName.Text = setting.AttributeName;
                    Label currentValue = new Label();
                    currentValue.AutoSize = true;
                    currentValue.Text = setting.CurrentValue;

                    _biosTableElements.BiosSettingsTable.Controls.Add(attributeName, 0, rowIndex);
                    _biosTableElements.BiosSettingsTable.Controls.Add(currentValue, 1, rowIndex);
                    if (setting.PossibleValues != null)
                    {
                        Label possibleValues = new Label();
                        possibleValues.AutoSize = true;
                        possibleValues.Text = string.Join(", ", setting.PossibleValues);
                        _biosTableElements.BiosSettingsTable.Controls.Add(possibleValues, 2, rowIndex);
                    }

                }
            }

        }


        // Network Methods
        private void GetNetworkTabElements(TabPage tabPage)
        {
            _networkTab = tabPage;
        }
        private void UpdateNetworkProperties()
        {
        }
        public void UpdateNetworkTabElements()
        {

        }


        // Printer Methods

        private Task<PrintServer> GetPrintServerAsync(string deviceName)
        {
            return Task.Run(() =>
            {
                return new PrintServer($@"\\{deviceName}");
            });
        }
        private Task<CimInstance[]> GetPrintersAsync(string namespaceName)
        {
            return Task.Run(() =>
            {
                return _cimHandler.GetInstances(namespaceName, "Win32_Printer");
            });

        }
        private void GetPrintersTabElements(TabPage tabPage)
        {
            _printersTab = tabPage;
            TableLayoutPanel printerTable = FindControl<TableLayoutPanel>(tabPage, "printerTable");
            TableLayoutPanel installedPrinterTable = FindControl<TableLayoutPanel>(printerTable, "installedPrinterTable");
            TableLayoutPanel defaultPrinterTable = FindControl<TableLayoutPanel>(printerTable, "defaultPrinterTable");

            _printerTabElements = new(installedPrinterTable, defaultPrinterTable);
        }
        private void UpdatePrinterProperties(Form form, CimInstance[] Printers, Dictionary<string, object> DefaultPrinter, string deviceName)
        {
            if (Printers == null || DefaultPrinter == null) return;
            List<Printer> printerList = new List<Printer>();

            form.Invoke((Action)(() =>
            {
                if (_printServer != null)
                {
                    foreach (PrintQueue printQueue in _printServer.GetPrintQueues())
                    {
                        printerList.Add(new Printer(printQueue.Name, printQueue.QueueDriver.Name, printQueue.QueuePort.Name));
                    }
                }
            }));
            _printerInformation = new(printerList);
            IsPrinterInformationInitialized.Value = true;
        }
        public void UpdatePrinterTabElements()
        {
            if (_printerInformation == null || _printerTabElements == null) { return; }

            foreach (Printer printer in _printerInformation.InstalledPrinters)
            {
                int rowIndex = _printerTabElements.InstalledPrinterTable.RowCount++;
                _printerTabElements.InstalledPrinterTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label printerName = new Label()
                {
                    Text = printer.DeviceId,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                };
                Label driverName = new Label()
                {
                    Text = printer.DriverName,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                };
                Label portName = new Label
                {
                    Text = printer.PortName,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                };
                Button printQueueButton = new Button
                {
                    Text = "Open Print Queue",
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                };
                printQueueButton.Click += PrintQueueButton_Click;

                TableLayoutControlCollection controls = _printerTabElements.InstalledPrinterTable.Controls;

                controls.Add(printQueueButton, _columnIndexOpenPrintQueueButton, rowIndex);
                controls.Add(printerName, _columnIndexPrinterName, rowIndex);
                controls.Add(driverName, _columnIndexPrinterDriverName, rowIndex);
                controls.Add(portName, _columnIndexPrinterPortName, rowIndex);

            }
        }

        private void PrintQueueButton_Click(object? sender, EventArgs e)
        {
            Button? button = sender as Button;
            TableLayoutPanel? panel = _printerTabElements?.InstalledPrinterTable;
            string? printerName = null;
            if (button is not null && panel is not null)
            {
                int rowIndex = panel.GetRow(button);

                foreach (Control control in panel.Controls)
                {
                    int controlRowIndex = panel.GetRow(control);
                    int controlColumnIndex = panel.GetColumn(control);
                    Console.WriteLine($"Control: {controlRowIndex}:{controlColumnIndex}, Printer Name: {rowIndex}:{_columnIndexPrinterName}");
                    Console.WriteLine($"Row: {rowIndex == controlRowIndex}, Column: {_columnIndexPrinterName == controlColumnIndex}");
                    if (panel.GetRow(control) == rowIndex && panel.GetColumn(control) == _columnIndexPrinterName)
                    {
                        if (control is not null && control is Label)
                        {
                            printerName = control.Text;
                            break;
                        }
                    }

                }
            }
            if (printerName is not null)
            {
                PrintQueue printQueue = new PrintQueue(_printServer, printerName, PrintSystemDesiredAccess.AdministratePrinter);

                PrinterQueueForm printerQueueForm = new PrinterQueueForm(printQueue);
                OverlayForm overlayForm = new OverlayForm(_reportForm!, printerQueueForm);

                if (_reportForm is not null)
                {
                    printerQueueForm.MaximumSize = _reportForm.Size;
                    overlayForm.Show(_reportForm);
                }
                else
                {
                    printerQueueForm.MaximumSize = Screen.PrimaryScreen?.Bounds.Size ?? new System.Drawing.Size(800, 600);
                }
                printerQueueForm.Shown += (sender, e) =>
                {
                    printerQueueForm.Location = new System.Drawing.Point(
                        _reportForm!.Location.X + (_reportForm.Width - printerQueueForm.Width) / 2,
                        _reportForm.Location.Y + (_reportForm.Height - printerQueueForm.Height) / 2
                    );
                };
                printerQueueForm.Show();

                printerQueueForm.FormClosed += (sender, e) =>
                {
                    overlayForm.Close();
                };
            }
        }


        // Security Methods
        private void GetSecurityTabElements(TabPage tabPage)
        {
            _securityTab = tabPage;
        }
        private void UpdateSecurityProperties()
        {
        }
        public void UpdateSecurityTabElements()
        {

        }


        // Software Methods
        private void GetSoftwareTabElements(TabPage tabPage)
        {
            _softwareTab = tabPage;
            DataGridView softwareGridView = FindControl<DataGridView>(tabPage, "softwareDataView");

            _softwareTableElements = new SoftwareTabElements(softwareGridView);
        }
        private void UpdateSoftwareProperties()
        {
            Dictionary<string, Dictionary<string, object>>? installedSoftware = GetInstalledSoftware();

            if (installedSoftware == null) return;

            Dictionary<string, Software> softwareDict = new Dictionary<string, Software>();
            foreach (KeyValuePair<string, Dictionary<string, object>> software in installedSoftware)
            {
                Dictionary<string, object> softwareProperties = software.Value;

                softwareProperties.TryGetValue("DisplayName", out object? displayNameObj);
                string displayName = (displayNameObj as string) ?? "Uknown";

                softwareProperties.TryGetValue("InstallDate", out object? installDateObj);
                string installDate = (installDateObj as string) ?? "Uknown";

                softwareProperties.TryGetValue("DisplayVersion", out object? versionObj);
                Version version = ParseVersion(versionObj);

                softwareProperties.TryGetValue("Publisher", out object? publisherObj);
                string publisher = (publisherObj as string) ?? "Unknown";

                if (_softwareInformation.InstalledSoftware != null && displayName != "Uknown")
                {
                    if (softwareDict.TryGetValue(displayName, out Software existingSoftware))
                    {
                        if (version >= existingSoftware.Version)
                        {
                            softwareDict[displayName] = new Software(displayName, version, publisher, installDate);
                        }
                    }
                    else
                    {
                        softwareDict.Add(displayName, new Software(displayName, version, publisher, installDate));
                    }

                }
            }
            _softwareInformation.InstalledSoftware = new List<Software>(softwareDict.Values).Distinct().OrderBy(name => name).ToList();

            IsSoftwareInformationInitialized.Value = true;
            Console.WriteLine("Software Info Initialized");
            _softwareTableElements.SoftwareDataView.DataSource = _softwareInformation.InstalledSoftware;
            _softwareTableElements.SoftwareDataView.AutoResizeColumns();
        }
        //public void UpdateSoftwareTabElements()
        //{
        //    Console.WriteLine("Entered UpdateSoftwareTabElements.");

        //    if (_softwareInformation.InstalledSoftware != null && _softwareTableElements != null)
        //    {
        //        TableLayoutControlCollection controls = _softwareTableElements.SoftwareTable.Controls;
        //        TableLayoutPanel softwareTable = _softwareTableElements.SoftwareTable;
        //        List<Software> installedSoftware = _softwareInformation.InstalledSoftware;

        //        Console.WriteLine($"Number of software items: {installedSoftware.Count}");
        //        Console.WriteLine($"Software table row count: {softwareTable.RowCount}");

        //        foreach (var software in installedSoftware)
        //        {
        //            int rowIndex = softwareTable.RowCount++;

        //            softwareTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        //            Label nameLabel = new Label() { Text = software.Name, AutoSize = true };
        //            Label versionLabel = new Label() { Text = software.Version.ToString(), AutoSize = true };
        //            Label publisherLabel = new Label() { Text = software.Publisher, AutoSize = true };
        //            Label installDateLabel = new Label() { Text = software.InstallDate, AutoSize = true };


        //            controls.Add(nameLabel, 0, rowIndex);
        //            controls.Add(versionLabel, 1, rowIndex);
        //            controls.Add(publisherLabel, 2, rowIndex);
        //            controls.Add(installDateLabel, 3, rowIndex);

        //            Console.WriteLine($"Added software: {software.Name} to the table.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("UpdateSoftwareTabElements: Either InstalledSoftware or SoftwareTableElements is null.");
        //    }
        //}


        // Registry and CIM Methods
        private Dictionary<string, object>? GetDepartmentRegistry()
        {
            return _registryManager?.LoadValues(RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Department");
        }

        private Dictionary<string, object>? GetDefaultPrinter()
        {
            return _registryManager?.LoadValues(RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Department\Printers");
        }

        private Dictionary<string, object>? GetBiosRegistryHive()
        {
            return _registryManager?.LoadValues(RegistryHive.LocalMachine, @"HARDWARE\DESCRIPTION\System\BIOS");
        }

        private Dictionary<string, Dictionary<string, object>>? GetInstalledSoftware()
        {
            Dictionary<string, Dictionary<string, object>>? _32BitSoftware = _registryManager?.LoadSubKeyValues(RegistryHive.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\");
            Dictionary<string, Dictionary<string, object>>? _64BitSoftware = _registryManager?.LoadSubKeyValues(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

            if (_32BitSoftware == null || _64BitSoftware == null)
            {
                return null;
            }

            var mergedDict = _32BitSoftware.Concat(_64BitSoftware)
                 .GroupBy(i => i.Key)
                 .ToDictionary(i => i.Key, i => i.First().Value);
            return mergedDict;
        }

        private IEnumerable<string>? GetBootOrder()
        {
            string namespaceName = @"root\dcim\sysman\biosattributes";
            string className = "BootOrder";

            try
            {
                CimInstance[] instances = _cimHandler?.GetInstances(namespaceName, className);
                if (instances == null || instances.Length == 0) return null;

                IEnumerable<string>? bootOrder = null;

                foreach (CimInstance instance in instances)
                {
                    if (instance.CimInstanceProperties["BootOrder"].Value is IEnumerable<string> bootOrderValue)
                    {
                        bootOrder = bootOrderValue;
                        break;
                    }
                }
                return bootOrder;
            }
            catch (Exception ex)
            {
                // Log exception or handle accordingly.
                return null;
            }
        }
        private List<BIOSSetting> GetBIOSSettings()
        {
            string namespaceName = @"root\dcim\sysman\biosattributes";
            List<BIOSSetting> bioSSettings = new List<BIOSSetting>();
            try
            {
                if (_cimHandler == null) return null;

                CimInstance[] enumerationAttributes = _cimHandler.GetInstances(namespaceName, "EnumerationAttribute");
                CimInstance[] integerAttributes = _cimHandler.GetInstances(namespaceName, "IntegerAttribute");
                CimInstance[] stringAttributes = _cimHandler.GetInstances(namespaceName, "StringAttribute");

                foreach (CimInstance instance in enumerationAttributes)
                {
                    string attributeName = instance.CimInstanceProperties["AttributeName"].Value as string;
                    string currentValue = instance.CimInstanceProperties["CurrentValue"].Value as string;
                    List<string> possibleValues = (instance.CimInstanceProperties["PossibleValue"].Value as string[])?.ToList();
                    bioSSettings.Add(new BIOSSetting(attributeName, currentValue, possibleValues));
                }
                foreach (CimInstance instance in integerAttributes)
                {
                    string attributeName = instance.CimInstanceProperties["AttributeName"].Value as string;
                    string currentValue = instance.CimInstanceProperties["CurrentValue"].Value as string;
                    bioSSettings.Add(new BIOSSetting(attributeName, currentValue));
                }
                foreach (CimInstance instance in stringAttributes)
                {
                    string attributeName = instance.CimInstanceProperties["AttributeName"].Value as string;
                    string currentValue = instance.CimInstanceProperties["CurrentValue"].Value as string;
                    bioSSettings.Add(new BIOSSetting(attributeName, currentValue));
                }
            }
            catch (Exception)
            {
                return null;
            }
            return bioSSettings;
        }
        private CimInstance[]? GetMemoryDevices(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_PhysicalMemory");
        }

        private CimInstance[]? GetVideoControllers(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_VideoController");
        }

        private CimInstance[]? GetLogicalDisks(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_LogicalDisk");
        }

        private CimInstance[]? GetHardDrives(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_DiskDrive");
        }

        private CimInstance[]? GetProcessors(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_Processor");
        }

        private CimInstance[]? GetActiveNetworkAdapters(string namespaceName)
        {

            return _cimHandler?.GetInstances(namespaceName, "Win32_NetworkAdapterConfiguration")
                .Where(adapter => adapter.CimInstanceProperties["IPAddress"] != null).ToArray();
        }

        private CimInstance GetOperatingSystem(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_OperatingSystem").FirstOrDefault()!;
        }

        private CimInstance GetComputerSystem(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_ComputerSystem").FirstOrDefault()!;
        }

        private CimInstance? GetSystemEnclosure(string namespaceName)
        {
            return _cimHandler?.GetInstances(namespaceName, "Win32_SystemEnclosure").FirstOrDefault()!;
        }



        private static void SetField<T>(ref T field, T value) where T : Control
        {
            if (field == null)
            {
                field = value;
            }
        }

        private static T FindControl<T>(Control parentControl, string targetControl) where T : Control
        {
            return parentControl.Controls.OfType<T>().FirstOrDefault(control => control.Name == targetControl)!;
        }

        private void InitializeHandlers(string deviceName)
        {
            _cimHandler = new(deviceName);
            _registryManager = new(deviceName);
            _pendingReboot = new(deviceName);


            if (deviceName == "localhost")
            {
                _printServer = new LocalPrintServer();
            }
            else
            {
                _printServer = new($@"\\{deviceName}");
            }
        }

        private Version ParseVersion(object? versionObj)
        {
            string versionString = versionObj as string ?? "0.0";

            if (Version.TryParse(versionString, out Version? version))
            {
                return version;
            }
            else
            {
                return new Version("0.0");
            }
        }
    }
}
