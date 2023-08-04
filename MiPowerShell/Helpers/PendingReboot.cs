using System.Collections.Concurrent;
using Microsoft.Win32;

namespace MiPowerShell.Helpers
{
    public class PendingReboot
    {
        private readonly List<Func<bool>> _tests;
        public bool IsPendingReboot { get; private set; } = false;
        public PendingReboot(string deviceName)
        {
            _tests = new()
            {
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\RebootPending"),
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\RebootInProgress"),
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired"),
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\PackagesPending"),
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\PostRebootReporting"),
                () => TestRegistryValueNotNull(deviceName, @"SYSTEM\CurrentControlSet\Control\Session Manager", "PendingFileRenameOperations"),
                () => TestRegistryValueNotNull(deviceName, @"SYSTEM\CurrentControlSet\Control\Session Manager", "PendingFileRenameOperations2"),
                () => TestRegistryValue(deviceName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", "DVDRebootSignal"),
                () => TestRegistryKey(deviceName, @"SOFTWARE\Microsoft\ServerManager\CurrentRebootAttemps"),
                () => TestRegistryValue(deviceName, @"SYSTEM\CurrentControlSet\Services\Netlogon", "JoinDomain"),
                () => TestRegistryValue(deviceName, @"SYSTEM\CurrentControlSet\Services\Netlogon", "AvoidSpnSet"),
                () => TestUpdateExeVolatileNotZero(deviceName, @"SOFTWARE\Microsoft\Updates"),
                () => TestComputerNamesMismatch(deviceName, @"SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName", @"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName"),
            };
        }
        public bool RunTests()
        {
            int i = 0;
            foreach (var test in _tests)
            {
                i++;
                Console.WriteLine($"Running Test {i}");
                if (test())
                {
                    Console.WriteLine($"Test {i} returned true");
                    IsPendingReboot = true;
                    break;
                }
            }
            return IsPendingReboot;
        }
        private static bool TestRegistryKey(string deviceName, string key)
        {
            try
            {
                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
                RegistryKey registryKey = baseKey.OpenSubKey(key, false)!;
                Console.WriteLine($"{key} returned {registryKey != null} : Registry Key: {registryKey}");
                return registryKey != null;
            }
            catch
            {
                return false;
            }
        }
        private static bool TestRegistryValue(string deviceName, string key, string value)
        {
            try
            {
                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
                RegistryKey registryKey = baseKey.OpenSubKey(key, false)!;
                if (registryKey != null)
                {
                    object registryValue = registryKey.GetValue(value)!;
                    Console.WriteLine($"{key} returned {registryValue != null} : Regsitry Value: {registryValue}");
                    return registryValue != null;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private static bool TestRegistryValueNotNull(string deviceName, string key, string value)
        {
            try
            {
                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
                RegistryKey registryKey = baseKey.OpenSubKey(key, false);
                if (registryKey != null)
                {
                    object registryValue = registryKey.GetValue(value);
                    if (registryValue != null)
                    {
                        Console.WriteLine($"{key}, {value} : Registry Value {registryValue}");
                        bool isNotNullOrEmpty = !string.IsNullOrEmpty(registryValue.ToString());
                        Console.WriteLine($"{key}\\{value} has a value that is not null or empty: {isNotNullOrEmpty}");
                        return isNotNullOrEmpty;
                    }
                }
                Console.WriteLine($"{key}\\{value} does not exist or its value is null.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while testing {key}\\{value}: {ex.Message}");
                return false;
            }
        }
        private static bool TestUpdateExeVolatileNotZero(string deviceName, string key)
        {
            try
            {
                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
                RegistryKey registryKey = baseKey.OpenSubKey(key, false)!;
                if (registryKey != null)
                {
                    int? updateExeVolatileValue = (int?)registryKey.GetValue("UpdateExeVolatile");
                    Console.WriteLine($"{key}, Update Exe Has Value: {updateExeVolatileValue.HasValue}, Update Value: {updateExeVolatileValue.Value} ");
                    Console.WriteLine(updateExeVolatileValue);
                    if (updateExeVolatileValue.HasValue && updateExeVolatileValue.Value != 0)
                        return true;
                }
            }
            catch
            {
                // Ignored
            }
            return false;
        }
        private static bool TestComputerNamesMismatch(string deviceName, string keyActive, string keyComputer)
        {
            try
            {
                RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
                RegistryKey activeKey = baseKey.OpenSubKey(keyActive, false)!;
                RegistryKey computerKey = baseKey.OpenSubKey(keyComputer, false)!;
                if (activeKey != null && computerKey != null)
                {
                    string? activeName = (string?)activeKey.GetValue("ComputerName");
                    string? computerName = (string?)computerKey.GetValue("ComputerName");
                    if (activeName != null && computerName != null)
                    {
                        Console.WriteLine($"Computer Names Match: {!activeName.Equals(computerName)}");
                        return !activeName.Equals(computerName);
                    }
                }
            }
            catch
            {
                // Ignored
            }
            return false;
        }
    }
}