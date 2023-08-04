using MiPowerShell.Models.WorkstationReport.Enums;
using DriveType = MiPowerShell.Models.WorkstationReport.Enums.DriveType;

namespace MiPowerShell.Models.WorkstationReport.Data
{
    public class HardwareInformation
    {
        public SystemInformation SystemInformation { get; set; }
        public List<Processor> Processors { get; set; }
        public List<MemoryModule> MemoryModules { get; set; }
        public List<PhysicalDisk> PhysicalDisks { get; set; }
        public List<LogicalDisk> LogicalDisks { get; set; }
        public List<VideoController> VideoControllers { get; set; }
        public HardwareInformation()
        {
            SystemInformation = new SystemInformation();
            Processors = new List<Processor>();
            MemoryModules = new List<MemoryModule>();
            PhysicalDisks = new List<PhysicalDisk>();
            LogicalDisks = new List<LogicalDisk>();
            VideoControllers = new List<VideoController>();
        }

    }
    //Win32_ComputerSystem
    public class SystemInformation
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string SMBIOSAssetTag { get; set; }
        public string SerialNumber { get; set; }
        public SystemInformation()
        {
            Model = string.Empty;
            Manufacturer = string.Empty;
            SMBIOSAssetTag = string.Empty;
            SerialNumber = string.Empty;
        }
    }
    //Win32_Processor
    public class Processor
    {
        public string Name { get; set; }
        public ProcessorType ProcessorType { get; set; }
        public Architecture Architecture { get; set; }
        public CpuStatus CPUStatus { get; set; }
        public Processor()
        {
            Name = string.Empty;
            ProcessorType = ProcessorType.Unknown;
            Architecture = Architecture.x64;
            CPUStatus = CpuStatus.Unknown;
        }
    }
    //Win32_PhysicalMemory
    public class MemoryModule
    {
        public string Name { get; set; }
        public ulong Capacity { get; set; }
        public uint Speed { get; set; }
        public TypeDetail Type { get; set; }
        public MemoryModule()
        {
            Name = string.Empty;
            Capacity = 0;
            Speed = 0;
            Type = TypeDetail.Unknown;
        }
    }
    //Win32_DiskDrive
    public class PhysicalDisk
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public ulong Size { get; set; }
        public string InterfaceType { get; set; }
        public string MediaType { get; set; }
        public uint Partitions { get; set; }

        public PhysicalDisk()
        {
            Name = string.Empty;
            Model = string.Empty;
            Size = 0;
            InterfaceType = string.Empty;
            MediaType = string.Empty;
            Partitions = 0;
        }
    }
    //Win32_LogicalDisk
    public class LogicalDisk
    {
        public string DeviceID { get; set; }
        public string Name { get; set; }
        public string FileSystem { get; set; }
        public DriveType DriveType { get; set; }
        public ulong FreeSpace { get; set; }
        public ulong Size { get; set; }

        public LogicalDisk()
        {
            DeviceID = string.Empty;
            Name = string.Empty;
            FileSystem = string.Empty;
            DriveType = DriveType.Unknown;
            FreeSpace = 0;
            Size = 0;
        }
    }
    //Win32_VideoController
    public class VideoController
    {
        public string Name { get; set; }
        public uint AdapterRAM { get; set; }
        public uint CurrentBitsPerPixel { get; set; }
        public string DriverVersion { get; set; }
        public DateTime DriverDate { get; set; }
        public string VideoProcessor { get; set; }

        public VideoController()
        {
            Name = "Unknown";
            AdapterRAM = 0;
            CurrentBitsPerPixel = 0;
            DriverVersion = "Unknown";
            DriverDate = DateTime.MinValue;
            VideoProcessor = "Unknown";
        }
    }
}
