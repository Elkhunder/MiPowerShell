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
        public bool _gettingSoftwareList { get; set; };
        
        public WorkstationReport()
        {
            GeneralPage GeneralPage = new();
            Location location = new();
            Centricity centricity = new();
            BuildInformation buildInformation = new();
            ScreenTimeOuts screenTimeOuts = new();
            AppList appList = new();
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
        //MaintenanceConfiguration
            //MaintenanceTime
            //LastBegan
            //LastCompleted
            //LastSucceeded
            //LastResult
            //RebootPending
            //MachineUpTime
        //PowerManagement
    }

    public class MaintenanceConfiguration
    {
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
        //SystemInformation
            //System/Model
            //Manufacturer
            //AssetTag
            //ServiceTag
        //Processors
            //Name
            //ProcessorType
            //Architechture
            //CPUStatus
        //Memory
            //Name
            //Capacity
            //Type
        //HardDrives
            //Name
            //Model
            //Size
            //Type
            //Partitions
        //DiskDrives
        //VideoControllers
        //Monitors
        //NetworkAdapters

    }

    public class SystemInformation
    {
        public string Model { get; set; }
        pubic string Manufacturer { get; set; }
        public string AssetTag { get; set; }
        public string ServiceTag { get; set; }
    }
    public class Processors
    {
        public string Name { get; set; }
        public string ProcessorType { get; set; }
        public string Architechture { get; set; }
        public string CPUStatus { get; set; }
    }
    public class Memory
    {
        public string Name { get; set; }
        public string Capacity { get; set; }
        public string Type { get; set; }
    }
    public class HardDrives
    {
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
    public class NetworkAdapters
    {
    }


    public class BiosPage
    {
        //BiosInformation
            //System/Model
            //BIOSVersion
            //BIOSDate
        //BootOrder
        //BIOSSettings
    }
    public class BiosInformation
    {
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
        //NetworkAdapters
            //Adapter
            //MacAddress
            //Interface
            //Status
        //IPConfiguration
            //Adapter
            //MacAddress
            //IPAddresses
            //SubnetMasks
            //Gateway
            //DHCP
            //DHCPServer
            //PrimaryWINSServer
            //SecondaryWINSServer

    }
    public class NetworkAdapters
    {
        public string Adapter { get; set; }
        public string MacAddress { get; set; }
        public string Interface { get; set; }
        public string Status { get; set; }
    }
    public class IPConfiguration
    {
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
        //InstalledPrinters
            //DeviceID
            //DriverName
            //PortName
        //PrinterDefaults
            //Account
            //Printer

    }
    public class InstalledPrinters
    {
        public string DeviceID { get; set; }
        public string DriverName { get; set; }
        public string PortName { get; set; }
    }
    public class PrinterDefaults
    {
        public string UserAccount { get; set; }
        public string Printer { get; set; }
    }


    public class SecurityPage
    {
        //LocalAccounts
        //LoacalAdmins
        //InstalledHotFixes
    }

    public class LocalAccounts
    {
        public string Name { get; set; }
    }
    public class LoacalAdmins
    {
        public string Name  { get; set; }
    }
    public class InstalledHotFixes
    {
        public string Name { get; set; }
        public string InstalledDate { get; set; }
    }


    public class SoftwarePage
    {
        AppList AppList = new();
    }

   
    public class AppList
    {
        public AppList()
        {
            SoftwareName = new List<string>();
            SoftwareVersion = new List<int>();
            Publisher = new List<string>();
            InstalledDate = new List<string>();

        }

        public List<string> SoftwareName { get; set; }
        public List<int> SoftwareVersion { get; set; }
        public List<string> Publisher { get; set; }
        public List<string> InstalledDate { get; set; }

    }

    
}
