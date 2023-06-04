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

    public class MaintenancePage
    {

    }
    public class HardwarePage
    {

    }
    public class BiosPage
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
    public class SecurityPage
    {
        //LocalAccounts
        //LoacalAdmins
        //InstalledHotFixes
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
}
