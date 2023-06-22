using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Models.WorkstationReport
{
    public class GeneralInformation
    {
        public General General { get; set;  }
        public Location Location { get; set; }
        public Centricity Centricity { get; set; }
        public ScreenTimeOuts ScreenTimeOuts { get; set; }
        public BuildInformation BuildInformation { get; set; }

        public GeneralInformation()
        {
            General = new General();
            Location = new Location();
            Centricity = new Centricity();
            ScreenTimeOuts = new ScreenTimeOuts();
            BuildInformation = new BuildInformation();
        }
    }

    public class General
    {
        public General()
        {
            DeviceName = string.Empty;
            OperatingSystem = string.Empty;
            ImageVersion = string.Empty;
            ImageMode = string.Empty;
            CurrentUser = string.Empty;
            IP4Address = new string[0];
            IP6Address = new string[0];
        }

        public string? DeviceName { get; set; }
        public string? OperatingSystem { get; set; }
        public string? ImageVersion { get; set; }
        public string? ImageMode { get; set; }
        public string? CurrentUser { get; set; }
        public string[]? IP4Address { get; set; }
        public string[]? IP6Address { get; set; }
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
