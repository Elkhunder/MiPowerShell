using Microsoft.Diagnostics.Runtime.Utilities;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Models;
using System.Data;

namespace MiPowerShell.Handlers.Commands
{
    internal class GetHardDriveSerialHandler : ICommandHandler
    {
        CimHandler? _cimHandler = new CimHandler();
        CimInstance[]? _cimInstance;
        HardDriveResults _results = new HardDriveResults();
        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            var (_, _, computerNames, _, _) = arguments;
            // TODO: Create and import _results class //

            // TODO: Update to for loop //
            foreach (var computerName in computerNames)
            {
                _results.TermID?.Add(computerName);
                bool isOnline = DeviceStatusChecked.IsDeviceOnline(computerName);
                if (!isOnline)
                {
                    _results.Error?.Add("Device Offline");
                    _results.Successful?.Add(false);
                    _results.StatusCode?.Add(-4);
                    continue;
                }
                string namespaceName = @"root\cimv2";
                string className = "Win32_DiskDrive";

                if(_cimHandler != null)
                {
                    try
                    {
                        _cimInstance = _cimHandler.GetInstances(namespaceName, className, computerName);
                    }
                    catch (Exception ex)
                    {
                        _results.Successful?.Add(false);
                        _results.Error?.Add(ex.Message);
                        _results.StatusCode?.Add(-2);
                    }
                }
                if (_cimInstance != null)
                {
                    string[] serialNumbers = new string[_cimInstance.Length];
                    for (int i = 0; i < _cimInstance.Length; i++)
                    {
                        serialNumbers[i] = (string)_cimInstance[i].CimInstanceProperties["SerialNumber"].Value;
                        
                    }
                    if(serialNumbers.Length > 0)
                    {
                        _results.SerialNumbers.Add(serialNumbers);
                        _results.Successful?.Add(true);
                    }
                }
            }
            DataTable table = new DataTable();

            // TODO: Update Columns //
            table.Columns.Add("TermID", typeof(string));
            table.Columns.Add("SerialNumbers", typeof(string));
            table.Columns.Add("Successful", typeof(bool));
            table.Columns.Add("Error", typeof(string));
            table.Columns.Add("StatusCode", typeof(int));

            for (int i = 0; i < _results.TermID?.Count; i++)
            {
                // TODO: Update //
                string termId = _results.TermID.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for TermID
                bool? successful = _results.Successful?.ElementAtOrDefault(i); // Allow nullable bool
                string error = _results.Error.ElementAtOrDefault(i) ?? string.Empty; // Handle null value for Error
                int? statusCode = _results.StatusCode?.ElementAtOrDefault(i); // Allow nullable int
                string serialNumbers = string.Join(",", _results.SerialNumbers.ElementAtOrDefault(i)!) ?? string.Empty; //Handle null value for SerialNumbers

                // TODO: Update //
                table.Rows.Add(termId, serialNumbers, successful, error, statusCode);
            }
            dataGridView.DataSource = table;
        }
        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }
    }
}
