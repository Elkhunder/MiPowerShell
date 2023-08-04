using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;


namespace MiPowerShell.Helpers.Managers
{
    internal class RegistryManager : IDisposable
    {
        //private RegistryKey _machineKey;
        //private RegistryKey _userKey;
        private RegistryKey? _registryKey;
        private string _deviceName;

        public RegistryManager(string deviceName)
        {
            _deviceName = deviceName;
            //_machineKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, deviceName);
            //_userKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, deviceName);
        }

        public Dictionary<string, Dictionary<string, object>> LoadSubKeyValues(RegistryHive keyName, string subKeyName)
        {
            var values = new Dictionary<string, Dictionary<string, object>>();

            try
            {
                using (var registryKey = RegistryKey.OpenRemoteBaseKey(keyName, _deviceName))
                using (var subKey = registryKey.OpenSubKey(subKeyName))
                {
                    if (subKey != null)
                    {
                        foreach (string name in subKey.GetSubKeyNames())
                        {
                            using (var subSubKey = subKey.OpenSubKey(name))
                            {
                                if (subSubKey != null)
                                {
                                    var subKeyValues = new Dictionary<string, object>();
                                    foreach (string valueName in subSubKey.GetValueNames())
                                    {
                                        subKeyValues[valueName] = subSubKey.GetValue(valueName);
                                    }
                                    values[name] = subKeyValues;
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            return values;
        }


        public Dictionary<string, object> LoadValues(RegistryHive keyName, string subKeyName)
        {
            var values = new Dictionary<string, object>();
            
            

            try
            {
                using (var registryKey = RegistryKey.OpenRemoteBaseKey(keyName, _deviceName))
                using (var subKey = registryKey.OpenSubKey(subKeyName))
                {
                    if (subKey != null)
                    {
                        foreach (string valueName in subKey.GetValueNames())
                        {
                            values[valueName] = subKey.GetValue(valueName);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }

            return values;
        }

        public void Dispose()
        {
            _registryKey?.Dispose();
        }
    }
}
