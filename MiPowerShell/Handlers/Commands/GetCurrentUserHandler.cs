using System.Data;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Models;

internal class GetCurrentUserHandler : ICommandHandler
{
    // TODO: Add Display Name //
    public void Handle(CommandArguments arguments, DataGridView dataGridView)
    {
        CurrentUserResults results = new();
        string[] computerNames = arguments.ComputerNames;

        foreach (string computerName in computerNames)
        {
            results.TermID?.Add(computerName);

            bool isOnline = DeviceStatusChecked.IsDeviceOnline(computerName);
            if (!isOnline)
            {
                results.Error?.Add("Device Offline");
                results.Successful?.Add(false);
                results.StatusCode?.Add(-4);
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
                if (ex.MessageId == "HRESULT 0x8007052e")
                {
                    Console.WriteLine("Admin credentials are not valid, use the CyberArk Password Vault to update your credentials and relaunch the application");
                    results.Error?.Add("Admin credentials are not valid, use the CyberArk Password Vault to update your credentials and relaunch the application");
                    results.Successful?.Add(false);
                    results.StatusCode?.Add(-3);
                }
                else
                {
                    Console.WriteLine($"TermID: {computerName}, Error: {ex.Message}");
                    results.Error?.Add(ex.Message);
                    results.Successful?.Add(false);
                    results.StatusCode?.Add(-2);
                }
                return;
            }
            string userName = (string)instance!.CimInstanceProperties["UserName"].Value;

            results.UserName?.Add(userName);
            results.Successful?.Add(true);
            results.StatusCode?.Add(0);
        }
        DataTable table = new();

        table.Columns.Add("TermID", typeof(string));
        table.Columns.Add("UserName", typeof(string));
        table.Columns.Add("Successful", typeof(bool));
        table.Columns.Add("Error", typeof(string));
        table.Columns.Add("StatusCode", typeof(int));

        for (int i = 0; i < results.TermID?.Count; i++)
        {
            string termId = results.TermID.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for TermID
            bool? successful = results.Successful.ElementAtOrDefault(i); // Allow nullable bool
            string error = results.Error.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for Error
            int? statusCode = results.StatusCode.ElementAtOrDefault(i); // Allow nullable int
            string userName = results.UserName.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for UserName

            // Add a new row to the DataTable
            table.Rows.Add(termId, userName, successful, error, statusCode);
        }
        dataGridView.DataSource = table;
    }

    public bool ValidateArguments(CommandArguments arguments)
    {
        return true;
    }
}