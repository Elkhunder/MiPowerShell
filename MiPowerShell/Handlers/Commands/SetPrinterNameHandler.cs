using System.Diagnostics;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;

internal class SetPrinterNameHandler : ICommandHandler
{
    public void Handle(CommandArguments arguments, DataGridView dataGridView)
    {
        var (computerNames, oldPrinterName, newPrinterName, _) = arguments;

        for (var i = 0; i < computerNames.Length; i++)
        {
            string namespaceName = @"root\cimv2";
            string className = "Win32_Printer";

            CimHandler cimHandler = new(computerNames[i], namespaceName, className);
            CimInstance[] cimInstance = cimHandler.CimInstances;

            if (cimInstance != null)
            {
                for (var j = 0; j < cimInstance.Length; j++)
                {
                    string printerName = (string)cimInstance[j].CimInstanceProperties["Name"].Value;
                    if (cimHandler != null && printerName == oldPrinterName)
                    {
                        CimMethodParametersCollection methodParameters = new()
                        {
                            CimMethodParameter.Create("NewPrinterName", newPrinterName, CimType.String, CimFlags.In)
                        };
                        CimSession cimSession = cimHandler.CimSession;
                        uint status = (uint)cimSession.InvokeMethod(cimInstance[j], "RenamePrinter", methodParameters).ReturnValue.Value;

                        switch (status)
                        {
                            case 0:
                                Debug.WriteLine($"Success, Status Code: {status}");
                                Console.WriteLine($"Success, Status Code: {status}");
                                return;
                            case 1:
                                Debug.WriteLine($"Access Denied, Status Code: {status}");
                                Console.WriteLine($"Access Denied, Status Code: {status}");
                                break;
                            case 1801:
                                Debug.WriteLine($"Invalid Printer Name, Status Code: {status}");
                                Console.WriteLine($"Invalid Printer Name, Status Code: {status}");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            cimHandler?.Dispose();

        }
    }
    public bool ValidateArguments(CommandArguments arguments)
    {
        return true;
    }
}