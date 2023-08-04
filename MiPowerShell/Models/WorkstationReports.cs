using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models
{
    

    

    
    
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
