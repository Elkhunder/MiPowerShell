using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Models;

namespace MiPowerShell.Handlers.Commands
{
    internal class RemoveUserProfileHandler : ICommandHandler
    {
        private readonly UserProfileResults _results = new();
        public void Handle(CommandArguments arguments, DataGridView dataGridView)
        {
            string[] termIds = arguments.ComputerNames;
            string userName = arguments.UserName;

            for (int i = 0; i < termIds.Length; i++)
            {
                _results.TermID.Add(termIds[i]);
                _results.UserName?.Add(userName);

                bool isOnline = DeviceStatusChecked.IsDeviceOnline(termIds[i]);
                if (!isOnline)
                {
                    _results.Error?.Add("Device Offline");
                    _results.Successful?.Add(false);
                    _results.StatusCode?.Add(-4);
                }

                UserProfileManager profileManager = new(userName, termIds[i]);
                CimInstance? profile = profileManager.GetProfile();

                

                if (profile != null)
                {
                    _results.LocalPath.Add((string)profile.CimInstanceProperties[itemName: "LocalPath"].Value);
                    _results.Loaded.Add((bool)profile.CimInstanceProperties[itemName: "Loaded"].Value);

                    if ((bool)profile.CimInstanceProperties["Loaded"].Value)
                    {
                        _results.Successful?.Add(false);
                        _results.StatusCode?.Add(-4);
                        _results.UserName?.Add(userName);
                        _results.Error?.Add("User is logged in");
                        continue;
                    }
                    int result = profileManager.RemoveProfile(profile);

                    _results.StatusCode?.Add(result);

                    if (result == 0)
                    {
                        _results.Successful?.Add(true);
                    }
                    else
                    {
                        _results.Successful?.Add(false);
                    }
                }
                else
                {
                    _results.Error?.Add("User profile not found");
                    _results.Successful?.Add(false);
                    _results.StatusCode?.Add(-1);
                }
                
            }
            DataTable table = new();

            table.Columns.Add("TermID", typeof(string));
            table.Columns.Add("UserName", typeof(string));
            table.Columns.Add("LocalPath", typeof(string));
            table.Columns.Add("Loaded", typeof(bool));
            table.Columns.Add("Error", typeof(string));
            table.Columns.Add("Successful", typeof(bool));
            table.Columns.Add("Status Code", typeof(int));

            for (int i = 0; i < _results.TermID.Count; i++)
            {
                string termId = _results.TermID.ElementAtOrDefault(i) ?? string.Empty;
                userName = _results.UserName?.ElementAtOrDefault(i) ?? string.Empty;
                string localPath = _results.LocalPath.ElementAtOrDefault(i) ?? string.Empty;
                bool loaded = _results.Loaded.ElementAtOrDefault(i);
                string error = _results.Error?.ElementAtOrDefault(i) ?? string.Empty;
                bool successful = _results.Successful.ElementAtOrDefault(i);
                int statusCode = _results.StatusCode.ElementAtOrDefault(i);

                table.Rows.Add(termId, userName, localPath, loaded, error, successful, statusCode);
            }
            dataGridView.DataSource = table;
        }

        public bool ValidateArguments(CommandArguments arguments)
        {
            return true;
        }
    }
}
