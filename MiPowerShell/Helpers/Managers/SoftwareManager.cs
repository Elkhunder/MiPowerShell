using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing.PrintSupport;

namespace MiPowerShell.Helpers.Managers
{
    public class SoftwareManager
    {
        private readonly string _deviceName;

        private string[] SubKeyNames = new string[2] { @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\" };
        

        public SoftwareManager(string deviceName)
        {
            _deviceName = deviceName ?? throw new ArgumentNullException(nameof(deviceName));
        }

        public async Task<List<string>> GetSoftwareNamesAsync(string deviceName)
        {
            var softwareNames = new ConcurrentBag<string>();
            using (var registryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName))
            {
                await ProcessSubKeysParallelAsync(registryKey, softwareNames);
            }
            return softwareNames.Distinct().OrderBy(name => name).ToList();

        }

        private async Task<ConcurrentBag<string>> ProcessSubKeysParallelAsync(RegistryKey registryKey, ConcurrentBag<string> result)
        {
            await Parallel.ForEachAsync(SubKeyNames, async (subKeyName, token) =>
            {
                await Task.Run(() => ExtractSoftwareNamesParallel(registryKey, subKeyName, result), token);
            });
            return result;
        }

        private void ExtractSoftwareNamesParallel(RegistryKey registryKey, string subKeyName, ConcurrentBag<string> result)
        {
            using (var subKey = registryKey.OpenSubKey(subKeyName))
            {
                if (subKey != null)
                {
                    foreach (string valueName in subKey.GetValueNames())
                    {
                        result.Add(valueName);
                    }
                }
            }
        }
    }
}
