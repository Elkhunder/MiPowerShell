using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    internal class WorkstationReport
    {
        public bool _gettingSoftwareList { get; set; }
        
        public WorkstationReport()
        {
            GeneralPage GeneralPage = new();
            Location location = new();
            Centricity centricity = new();
            BuildInformation buildInformation = new();
            ScreenTimeOuts screenTimeOuts = new();
            //AppList appList = new();
        }
    }

    public class GeneralPage
    {
        GeneralInformation GeneralInformation = new();
        ScreenTimeOuts ScreenTimeOuts = new();
        Centricity Centricity = new();
        Location Location = new();
        BuildInformation BuildInformation = new();
    }

    public class GeneralInformation
    {
        public GeneralInformation()
        {
            TermID = string.Empty;
            OperatingSystem = string.Empty;
            ImageVersion = string.Empty;
            ImageMode = string.Empty;
            CurrentUser = string.Empty;
            IpAddress = string.Empty;
        }

        public string? TermID { get; set; }
        public string? OperatingSystem { get; set; }
        public string? ImageVersion { get; set; }
        public string? ImageMode { get; set; }
        public string? CurrentUser { get; set; }
        public string? IpAddress { get; set; }


    }

    public class Location
    {
        public Location()
        {
            Department = string.Empty;
            BusinessUnit = string.Empty;
            SupportUnit = string.Empty;
            Building = string.Empty;
            Room = string.Empty;
            PhoneNumber = string.Empty;
        }

        public string? Department { get; set; }
        public string? BusinessUnit { get; set; }
        public string? SupportUnit { get; set; }
        public string? Building { get; set; }
        public string? Room { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class Centricity
    {
        public Centricity()
        {
            Timer = string.Empty;
            Environment = string.Empty;
        }

        public string? Timer { get; set; }
        public string? Environment { get; set; }

    }

    public class ScreenTimeOuts
    {
        public ScreenTimeOuts()
        {
            ScreenSaverTimeout = string.Empty;
            ScreenLockTimeout = string.Empty;
            AutoLogoffTimeout = string.Empty;
        }

        public string? ScreenSaverTimeout { get; set; }
        public string? ScreenLockTimeout { get; set; }
        public string? AutoLogoffTimeout { get; set; }

    }

    public class BuildInformation
    {
        public BuildInformation()
        {
            BuiltBy = string.Empty;
            BuildDate = string.Empty;
            BuildResult = string.Empty;
        }

        public string? BuiltBy { get; set; }
        public string? BuildDate { get; set; }
        public string? BuildResult { get; set; }

    }


    public class MaintenancePage
    {
        MaintenanceConfiguration maintenanceConfiguration = new();
        PowerManagement powerManagement = new();
    }

    public class MaintenanceConfiguration
    {
        public MaintenanceConfiguration()
        {
            MaintenanceTime = string.Empty;
            LastBegan = string.Empty;
            LastCompleted = string.Empty;
            LastSucceeded = string.Empty;
            RebootPending = string.Empty;
            MachineUpTime = string.Empty;
        }

        public string MaintenanceTime { get; set; }
        public string LastBegan { get; set; }
        public string LastCompleted { get; set; }
        public string LastSucceeded { get; set; }
        public string RebootPending { get; set; }
        public string MachineUpTime { get; set; }
    }

    public class PowerManagement
    {
    }


    public class HardwarePage
    {
        SystemInformation systemInformation = new();
        Memory Memory = new Memory();
        HardDrives hardDrives = new();
        DiskDrives diskDrives = new();
        VideoControllers videoControllers = new();
        Monitors monitors = new();
        NetworkAdapters networkAdapters = new();
    }

    public class SystemInformation
    {
        public SystemInformation()
        {
            Model = string.Empty;
            Manufacturer = string.Empty;
            AssetTag = string.Empty;
            ServiceTag = string.Empty;
        }

        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string AssetTag { get; set; }
        public string ServiceTag { get; set; }
    }
    public class Processors
    {
        public Processors()
        {
            Name = string.Empty;
            ProcessorType = string.Empty;
            Architechture = string.Empty;
            CPUStatus = string.Empty;
        }

        public string Name { get; set; }
        public string ProcessorType { get; set; }
        public string Architechture { get; set; }
        public string CPUStatus { get; set; }
    }
    public class Memory
    {
        public Memory()
        {
            Name = string.Empty;
            Capacity = string.Empty;
            Type = string.Empty;
        }

        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Type { get; set; }
    }
    public class HardDrives
    {
        public HardDrives()
        {
            Name = string.Empty;
            Model = string.Empty;
            Size = string.Empty;
            Type = string.Empty;
            Partitions = string.Empty;
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Partitions {get; set; }
    }
    public class DiskDrives
    {
    }
    public class VideoControllers
    {
    }
    public class Monitors
    {
    }


    public class BiosPage
    {
        BIOSInformation biosInformation = new();
        BootOrder bootOrder = new();
        BIOSSettings biosSettings = new();
    }
    public class BIOSInformation
    {
        public BIOSInformation()
        {
            Model = string.Empty;
            BIOSVersion = string.Empty;
            BIOSDate = string.Empty;
        }

        public string Model { get; set; }
        public string BIOSVersion { get; set; }
        public string BIOSDate { get; set; }
    }
    public class BootOrder
    {
    }
    public class BIOSSettings
    {
    }


    public class NetworkConfigPage
    {
        NetworkAdapters networkAdapters = new();
        IPConfiguration ipConfiguration = new();

    }
    public class NetworkAdapters
    {
        public NetworkAdapters()
        {
            Adapter = string.Empty;
            MacAddress = string.Empty;
            Interface = string.Empty;
            Status = string.Empty;
        }

        public string Adapter { get; set; }
        public string MacAddress { get; set; }
        public string Interface { get; set; }
        public string Status { get; set; }
    }
    public class IPConfiguration
    {
        public IPConfiguration()
        {
            Adapter = string.Empty;
            MacAddress = string.Empty;
            IPAddress = string.Empty;
            SubnetMasks = string.Empty;
            Gateway = string.Empty;
            DHCP = string.Empty;
            DHCPServer =  string.Empty;   
            PrimaryWINSServer = string.Empty;
            SecondaryWINSServer = string.Empty;
        }

        public string Adapter { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string SubnetMasks { get; set; }
        public string Gateway { get; set; }
        public string DHCP { get; set; }
        public string DHCPServer { get; set; }
        public string PrimaryWINSServer { get; set; }
        public string SecondaryWINSServer { get; set; }
    }


    public class PrintersPage
    {
        InstalledPrinters installedPrinters = new();
        PrinterDefaults printerDefaults = new();
    }
    public class InstalledPrinters
    {
        public InstalledPrinters()
        {
            DeviceID = string.Empty;
            DriverName = string.Empty;
            PortName = string.Empty;
        }

        public string DeviceID { get; set; }
        public string DriverName { get; set; }
        public string PortName { get; set; }
    }
    public class PrinterDefaults
    {
        public PrinterDefaults()
        {
            UserAccount = string.Empty;
            Printer = string.Empty;
        }

        public string UserAccount { get; set; }
        public string Printer { get; set; }
    }


    public class SecurityPage
    {
        LocalAccounts localAccounts = new();
        LocalAdmins localAdmins = new();
        InstalledHotFixes installedHotFixes = new();

    }

    public class LocalAccounts
    {
        public LocalAccounts()
        {
            Name = new List<string>();
        }

        public List<string> Name { get; set; }
    }
    public class LocalAdmins
    {
        public LocalAdmins()
        {
            Name = new List<string>();
        }

        public List<string> Name  { get; set; }
    }
    public class InstalledHotFixes
    {
        public InstalledHotFixes()
        {
            Name = new List<string>();
            InstalledDate = new List<DateTime>();
        }

        public List<string> Name { get; set; }
        public List<DateTime> InstalledDate { get; set; }
    }


    public class SoftwarePage
    {
        AppList appList = new();
    }

   
    public class AppList
    {
        public AppList()
        {
            SoftwareName = new List<string>();
            SoftwareVersion = new List<int>();
            Publisher = new List<string>();
            InstalledDate = new List<DateTime>();

        }

        public List<string> SoftwareName { get; set; }
        public List<int> SoftwareVersion { get; set; }
        public List<string> Publisher { get; set; }
        public List<DateTime> InstalledDate { get; set; }

    }
    
}
