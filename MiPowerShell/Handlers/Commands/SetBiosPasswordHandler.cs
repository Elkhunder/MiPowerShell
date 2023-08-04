using System.Data;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Models;

namespace MiPowerShell.Handlers.Commands
{
    internal class SetBiosPasswordHandler : ICommandHandler
    {
        private string? _result;
        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            BiosPasswordResults results = new();

            var (computerNames, biosPassword, newBiosPassword) = arguments;

            foreach (var computerName in computerNames)
            {
                results.TermID?.Add(computerName);
                bool isOnline = DeviceStatusChecked.IsDeviceOnline(computerName);

                if (!isOnline)
                {
                    _result = "Offline";
                    Console.WriteLine($"TermID: {computerName}, Result: {_result}");
                    results.Error?.Add("Device Offline");
                    results.Successful?.Add(false);
                    results.StatusCode?.Add(-1);
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
                catch (CimException ex)
                {
                    Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    results.Error?.Add(ex.Message);
                    results.Successful?.Add(false);
                    results.StatusCode?.Add(-2);
                }

                string manufacturer = (string)instance!.CimInstanceProperties["Manufacturer"].Value;

                if (manufacturer == null)
                {
                    results.Error?.Add("Unable to determine device manufacturer");
                    results.Successful?.Add(false);
                    results.StatusCode?.Add(-3);
                    return;
                }

                if (manufacturer.Contains("Dell"))
                {
                    string nameSpace = @"root\dcim\sysman\wmisecurity";
                    className = "PasswordObject";
                    instance = cimSession.QueryInstances(nameSpace, "WQL", $"SELECT * FROM {className} WHERE NameId = 'Admin'").First();

                    try
                    {
                        instance = cimSession.QueryInstances(nameSpace, "WQL", $"SELECT * FROM {className} WHERE NameId = 'Admin'").First();

                        bool isBiosPasswordSet = Convert.ToBoolean(instance.CimInstanceProperties["IsPasswordSet"].Value);
                        bool isBiosPasswordValue = Convert.ToBoolean(biosPassword.Length);
                        if (isBiosPasswordSet && !isBiosPasswordValue)
                        {
                            _result = "BIOS password is set, to change provide the current BIOS password";
                            Console.WriteLine($"TermID: {computerName}, Result: {_result}");
                            results.Error?.Add("BIOS Password is already set, if you wish to update it provide the current BIOS password when running the command");
                            results.Successful?.Add(false);
                            results.StatusCode?.Add(-4);
                            results.BiosPasswordIsSet?.Add(true);
                            continue;
                        }
                    }
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                        results.Error?.Add(nameSpace + ": " + ex.Message);
                        results.Successful?.Add(false);
                        results.StatusCode?.Add(-2);
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
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                        results.Error?.Add(nameSpace + ": " + ex.Message);
                        results.Successful?.Add(false);
                        results.StatusCode?.Add(-2);
                    }

                    string oldPassword = ConvertSecureStringToPlainText(biosPassword);
                    string newPassword = ConvertSecureStringToPlainText(newBiosPassword);

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
                        CimMethodParameter.Create("NewPassword", newPassword, CimType.String, CimFlags.In)
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
                                _result = "BIOS password set successfully";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                                results.Successful?.Add(true);
                                results.BiosPasswordIsSet?.Add(false);
                                results.StatusCode?.Add(statusCode);
                            }
                            else
                            {
                                _result = "Failed to set BIOS password";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                                results.Successful?.Add(false);
                                results.Error?.Add("Failed to set BIOS password");
                                results.StatusCode?.Add(statusCode);
                                results.BiosPasswordIsSet?.Add(true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status parameter not found");
                            results.Successful?.Add(false);
                            results.Error?.Add("Status parameter not found");
                            results.StatusCode?.Add(-5);
                            results.BiosPasswordIsSet?.Add(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        results.Successful?.Add(false);
                        results.Error?.Add(nameSpace + ":" + ex.Message);
                        results.StatusCode?.Add(-2);
                        results.BiosPasswordIsSet?.Add(true);
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
                        bool isBiosPasswordValue = Convert.ToBoolean(biosPassword.Length);
                        if (isBiosPasswordSet && !isBiosPasswordValue)
                        {
                            _result = "BIOS password is set, to change provide the current BIOS password";
                            Console.WriteLine($"termid: {computerName}, result: {_result}");
                            results.Error?.Add("BIOS Password is already set, if you wish to update it provide the current BIOS password when running the command");
                            results.Successful?.Add(false);
                            results.StatusCode?.Add(-4);
                            results.BiosPasswordIsSet?.Add(true);
                            continue;
                        }
                    }
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                        results.Successful?.Add(false);
                        results.Error?.Add(nameSpace + ":" + ex.Message);
                        results.StatusCode?.Add(-2);
                        results.BiosPasswordIsSet?.Add(true);
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
                    catch (CimException ex)
                    {
                        Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                        results.Successful?.Add(false);
                        results.Error?.Add(nameSpace + ":" + ex.Message);
                        results.StatusCode?.Add(-2);
                        results.BiosPasswordIsSet?.Add(true);
                    }
                    string oldPassword = ConvertSecureStringToPlainText(biosPassword);
                    string newPassword = ConvertSecureStringToPlainText(newBiosPassword);

                    var methodParameters = new CimMethodParametersCollection
                    {
                        CimMethodParameter.Create("Name", settingName, CimFlags.Parameter),
                        CimMethodParameter.Create("Value", $"<utf-16/>{newPassword}", CimFlags.Parameter),
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
                                _result = "BIOS password set successfully.";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                                results.Successful?.Add(true);
                                results.BiosPasswordIsSet?.Add(false);
                                results.StatusCode?.Add((int)statusCode);
                            }
                            else
                            {
                                _result = "Failed to set BIOS password";
                                Console.WriteLine($"TermID: {computerName}, Status Code: {statusCode}, Result: {_result}");
                                results.Successful?.Add(false);
                                results.Error?.Add("Failed to set BIOS password");
                                results.StatusCode?.Add((int)statusCode);
                                results.BiosPasswordIsSet?.Add(true);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Status parameter not found");
                            results.Successful?.Add(false);
                            results.Error?.Add("Status parameter not found");
                            results.StatusCode?.Add(-5);
                            results.BiosPasswordIsSet?.Add(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        results.Successful?.Add(false);
                        results.Error?.Add(nameSpace + ":" + ex.Message);
                        results.StatusCode?.Add(-2);
                        results.BiosPasswordIsSet?.Add(true);
                    }
                    finally
                    {
                        instance.Dispose();
                    }
                }
            }
            DataTable table = new();

            table.Columns.Add("TermID", typeof(string));
            table.Columns.Add("Successful", typeof(bool));
            table.Columns.Add("Error", typeof(string));
            table.Columns.Add("StatusCode", typeof(int));
            table.Columns.Add("BiosPasswordIsSet", typeof(bool));

            for (int i = 0; i < results.TermID?.Count; i++)
            {
                string termId = results.TermID.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for TermID
                bool? successful = results.Successful.ElementAtOrDefault(i); // Allow nullable bool
                string error = results.Error.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for Error
                int? statusCode = results.StatusCode.ElementAtOrDefault(i); // Allow nullable int
                bool? biosPasswordIsSet = results.BiosPasswordIsSet.ElementAtOrDefault(i); // Allow nullable bool

                // Add a new row to the DataTable
                table.Rows.Add(termId, successful, error, statusCode, biosPasswordIsSet);
            }
            dataGridView.DataSource = table;
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
            if (arguments.ComputerNames == null || arguments.ComputerNames.Any(string.IsNullOrEmpty))
            {
                return false;
            }
            return true;
        }
    }
}
