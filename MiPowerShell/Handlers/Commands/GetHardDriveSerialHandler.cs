using System.Data;
using Microsoft.Diagnostics.Runtime.Utilities;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Models;

namespace MiPowerShell.Handlers.Commands
{
    internal class GetHardDriveSerialHandler : ICommandHandler
    {
        CimHandler? _cimHandler;
        CimInstance[]? _cimInstance;
        readonly HardDriveResults _results = new();
        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            string[] computerNames = arguments.ComputerNames;
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

                _cimHandler = new CimHandler(computerName, namespaceName, className);

                if (_cimHandler != null)
                {
                    try
                    {
                        _cimInstance = _cimHandler.CimInstances;
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
                    string[] driveNames = new string[_cimInstance.Length];
                    for (int i = 0; i < _cimInstance.Length; i++)
                    {
                        serialNumbers[i] = (string)_cimInstance[i].CimInstanceProperties["SerialNumber"].Value;
                        driveNames[i] = (string)_cimInstance[i].CimInstanceProperties["Caption"].Value;

                    }
                    if (serialNumbers.Length > 0)
                    {
                        _results.SerialNumbers.Add(serialNumbers);
                        _results.Successful?.Add(true);
                    }
                    if (driveNames.Length > 0)
                    {
                        _results.Name.Add(driveNames);
                    }
                }
            }
            DataTable table = new();

            // TODO: Update Columns //
            table.Columns.Add("TermID", typeof(string));
            table.Columns.Add("DriveName", typeof(string));
            table.Columns.Add("SerialNumbers", typeof(string));
            table.Columns.Add("Successful", typeof(bool));
            table.Columns.Add("Error", typeof(string));
            table.Columns.Add("StatusCode", typeof(int));

            for (int i = 0; i < _results.TermID?.Count; i++)
            {
                // TODO: Update //
                string termId = _results.TermID.ElementAtOrDefault(i) ?? string.Empty;
                bool? successful = _results.Successful?.ElementAtOrDefault(i);
                string error = _results.Error.ElementAtOrDefault(i) ?? string.Empty;
                int? statusCode = _results.StatusCode?.ElementAtOrDefault(i);
                string serialNumbers = string.Join(",", _results.SerialNumbers.ElementAtOrDefault(i)!) ?? string.Empty;
                string driveName = string.Join(",", _results.Name.ElementAtOrDefault(i)!) ?? string.Empty;

                // TODO: Update //
                table.Rows.Add(termId, driveName, serialNumbers, successful, error, statusCode);
            }
            dataGridView.DataSource = table;
        }
        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }
    }
}
