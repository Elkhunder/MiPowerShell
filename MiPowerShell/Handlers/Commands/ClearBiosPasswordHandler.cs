using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using Microsoft.Management.Infrastructure.Generic;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using System;
using System.Management;
using System.Management.Automation;
using CimType = Microsoft.Management.Infrastructure.CimType;
using MiPowerShell.Arguments.BiosCommands;
using System.Security;
using System.Runtime.InteropServices;
using Namotion.Reflection;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.DirectoryServices.Protocols;

namespace MiPowerShell.Handlers.Commands
{
    internal class ClearBiosPasswordHandler : ICommandHandler
    {
        private string? _result;
        public void Handle(CommandArguments arguments)
        {
            var (biosPassword, _, computerNames, _, _) = arguments;
            
            foreach (var computerName in computerNames)
            {
                bool isOnline = DeviceStatusChecked.IsDeviceOnline(computerName);
                if (!isOnline)
                {
                    _result = "Offline";
                    Console.WriteLine($"TermID: {computerName}, Result: {_result}");
                    continue;
                }
                string namespaceName = @"root\cimv2";
                string className = "Win32_ComputerSystem";

                CimSession cimSession = CimSession.Create(computerName);
                CimInstance? instance = null;
                try
                {
                    instance = cimSession.EnumerateInstances(namespaceName, className).First();
                }
                catch(CimException ex)
                {
                    if (ex.MessageId == "HRESULT 0x8007052e")
                    {
                        Console.WriteLine("Admin credentials are not valid, use the CyberArk Password Vault to update your credentials and relaunch the application");
                    }
                    else
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    }
                    return;
                }

                string manufacturer = (string)instance!.CimInstanceProperties["Manufacturer"].Value;

                if (manufacturer == null) return;

                if (manufacturer.Contains("Dell"))
                {
                    string nameSpace = @"root\dcim\sysman\wmisecurity";
                    className = "PasswordObject";
                    try
                    {
                        instance = cimSession.QueryInstances(nameSpace, "WQL", $"SELECT * FROM {className} WHERE NameId = 'Admin'").First();

                        bool isBiosPasswordSet = Convert.ToBoolean(instance.CimInstanceProperties["IsPasswordSet"].Value);
                        if (!isBiosPasswordSet)
                        {
                            _result = "BIOS password is not set";
                            Console.WriteLine($"TermID: {computerName}, Result: {_result}");
                            continue;
                        }
                    }
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    }
                    finally
                    {
                        instance.Dispose();
                    }

                    className = "SecurityInterface";

                    try
                    {
                        instance = cimSession.EnumerateInstances(nameSpace, className).First();
                    }
                    catch(CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    }
                    
                    string oldPassword = ConvertSecureStringToPlainText(biosPassword);

                    var encoder = new System.Text.UTF8Encoding();
                    byte[] secHandle = encoder.GetBytes(oldPassword);
                    uint secHndCount = (uint)secHandle.Length;

                    var methodParameters = new CimMethodParametersCollection
                    {
                        CimMethodParameter.Create("SecType", 1, CimType.UInt32, CimFlags.In),
                        CimMethodParameter.Create("SecHndCount", secHndCount, CimType.UInt32, CimFlags.In),
                        CimMethodParameter.Create("SecHandle", secHandle, CimType.UInt8Array, CimFlags.In),
                        CimMethodParameter.Create("NameId", "Admin", CimType.String, CimFlags.In),
                        CimMethodParameter.Create("OldPassword", oldPassword, CimType.String, CimFlags.In),
                        CimMethodParameter.Create("NewPassword", "", CimType.String, CimFlags.In)
                    };

                    try
                    {
                        var result = cimSession.InvokeMethod(instance, "SetNewPassword", methodParameters);
                        var statusParam = result.OutParameters["Status"];
                        if (statusParam != null && statusParam.Value != null)
                        {
                            int statusCode = (int)statusParam.Value;
                            Console.WriteLine($"Status Code: {statusCode}");

                            if (statusCode == 0)
                            {
                                _result = "BIOS password cleared successfully";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                            }
                            else
                            {
                                _result = "Failed to clear BIOS password";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status parameter not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    finally
                    {
                        instance.Dispose();
                    }
                }
                if (manufacturer.Contains("HP"))
                {
                    string nameSpace = @"root\HP\InstrumentedBios";
                    className = "HP_BiosSetting";
                    string settingName = "Setup Password";
                    try
                    {
                        instance = cimSession.QueryInstances(nameSpace, "WQL", $"SELECT * FROM {className} WHERE Name = '{settingName}'").First();

                        bool isBiosPasswordSet = Convert.ToBoolean(instance.CimInstanceProperties["isSet"].Value);

                        if (!isBiosPasswordSet)
                        {
                            _result = "bios password is not set";
                            Console.WriteLine($"termid: {computerName}, result: {_result}");
                            continue;
                        }
                    }
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    }
                    finally
                    {
                        instance.Dispose();
                    }

                    className = "HPBIOS_BIOSSettingInterface";

                    try
                    {
                        instance = cimSession.EnumerateInstances(nameSpace, className).First();
                    }
                    catch(CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                        continue;
                    }
                    string oldPassword = ConvertSecureStringToPlainText(biosPassword);
                    
                    var methodParameters = new CimMethodParametersCollection
                    {
                        CimMethodParameter.Create("Name", settingName, CimFlags.Parameter),
                        CimMethodParameter.Create("Value", "<utf-16/>", CimFlags.Parameter),
                        CimMethodParameter.Create("Password", $"<utf-16/>{oldPassword}", CimFlags.Parameter)
                    };

                    try
                    {
                        // Set the BIOS password setting to the new password
                        CimMethodResult result = cimSession.InvokeMethod(instance, "SetBIOSSetting", methodParameters);
                        var statusParameter = result.OutParameters["Return"];

                        if (statusParameter != null && statusParameter.Value != null)
                        {
                            uint statusCode = (uint)statusParameter.Value;

                            if (statusCode == 0)
                            {
                                _result = "BIOS password cleared successfully.";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                            }
                            else
                            {
                                _result = "Failed to clear BIOS password";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    finally
                    {
                        instance.Dispose();
                    }  
                }
            }
        }

        private static string ConvertSecureStringToPlainText(SecureString biosPassword)
        {
            string? oldPassword = string.Empty;
            IntPtr bstr = IntPtr.Zero;
            try
            {
                bstr = Marshal.SecureStringToBSTR(biosPassword);
                oldPassword = Marshal.PtrToStringUni(bstr);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(bstr);
            }
            return oldPassword ?? string.Empty;
            
        }

        public bool ValidateArguments(CommandArguments arguments)
        {
            if (arguments == null)
            {
                return false;
            }
            if (arguments.ComputerNames == null || arguments.ComputerNames.Any(string.IsNullOrEmpty) && arguments.Local == (DialogResult)DialogResult.None)
            {
                return false;
            }
            if(arguments.Local == (DialogResult) DialogResult.Yes)
            {
                arguments.ComputerNames = new string[] { "localhost" };
            }
            return true;
        }
    }
}
