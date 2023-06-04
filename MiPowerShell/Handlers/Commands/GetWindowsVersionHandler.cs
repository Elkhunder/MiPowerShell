using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Runtime.Utilities;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Models;

namespace MiPowerShell.Handlers.Commands
{
    internal class GetWindowsVersionHandler : ICommandHandler
    {
        private CimHandler? _cimHandler;
        private CimInstance[]? _cimInstance;
        private readonly WindowsVersionResults _results = new();

        private readonly Dictionary<string, string> _buildToVersionMap = new()
        {
            { "10240", "1507" },
            { "10586", "1511" },
            { "14393", "1607" },
            { "15063", "1703" },
            { "16299", "1709" },
            { "17134", "1803" },
            { "17763", "1809" },
            { "18362", "1903" },
            { "18363", "1909" },
            { "19041", "2004" },
            { "19042", "20H2" },
            { "19043", "21H1" },
            { "19044", "21H2" },
            { "19045", "22H2" }
        };
        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            string[] computerNames = arguments.ComputerNames;

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
                string className = "CIM_OperatingSystem";

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
                    string buildNumber = (string)_cimInstance.FirstOrDefault()!.CimInstanceProperties["BuildNumber"].Value;
                    if (buildNumber != null && _buildToVersionMap.ContainsKey(buildNumber))
                    {
                        /* TODO:
                         * Handle Empty or Null Build Number
                         * Handle Invalid Build Number
                         * Currently these cases are both handled by setting the windows version to uknown
                         * It would be beneficial to have a more specific handling of both cases seperately
                        */

                        _results.Successful?.Add(true);
                        _results.WindowsVersion.Add(_buildToVersionMap[buildNumber]);
                    }
                    else
                    {
                        _results.Successful?.Add(false);
                        _results.WindowsVersion.Add("unknown");
                    }
                }
                _cimHandler?.Dispose();
            }
            DataTable table = new();

            // TODO: Update Columns //
            table.Columns.Add("TermID", typeof(string));
            table.Columns.Add("WindowsVersion", typeof(string));
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
                string windowsVersion = _results.WindowsVersion.ElementAtOrDefault(i) ?? string.Empty; //Handle null value for SerialNumbers

                // TODO: Update //
                table.Rows.Add(termId, windowsVersion, successful, error, statusCode);
            }
            dataGridView.DataSource = table;
        }

        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }
    }
}
