using System.Data;
using Microsoft.Management.Infrastructure;
using MiPowerShell.Arguments;
using MiPowerShell.Helpers;
using MiPowerShell.Helpers.Managers;
using MiPowerShell.Models;

internal class GetUserProfileHandler : ICommandHandler
{
    private readonly UserProfileResults _results = new();
    public void Handle(CommandArguments arguments, DataGridView dataGridView)
    {
        string[] termIds = arguments.ComputerNames;
        string userName = arguments.UserName;

        for (int i = 0; i < termIds.Length; i++)
        {
            _results.TermID.Add(item: termIds[i]);

            bool isOnline = DeviceStatusChecked.IsDeviceOnline(termIds[i]);
            if (!isOnline)
            {
                _results.Error?.Add("Device Offline");
                _results.Successful?.Add(false);
                _results.StatusCode?.Add(-4);
                continue;
            }

            UserProfileManager userProfileManager = new(userName, termIds[i]);

            CimInstance? profile = userProfileManager.GetProfile();

            if (profile != null)
            {
                _results.UserName.Add(userName);
                _results.LocalPath.Add((string)profile.CimInstanceProperties[itemName: "LocalPath"].Value);
                _results.Loaded.Add((bool)profile.CimInstanceProperties[itemName: "Loaded"].Value);
                _results.Successful?.Add(true);
                _results.StatusCode?.Add(0);
            }
            else
            {
                _results.UserName.Add(userName);
                _results.LocalPath.Add(string.Empty);
                _results.Error?.Add("User profile not found");
                _results.Successful?.Add(false);
                _results.StatusCode?.Add(-1);
            }

            // Add results to data grid view and add some error output to the data grid view
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
            userName = _results.UserName.ElementAtOrDefault(i) ?? string.Empty;
            string localPath = _results.LocalPath.ElementAtOrDefault(i) ?? string.Empty;
            bool loaded = _results.Loaded.ElementAtOrDefault(i);
            string error = _results.Error.ElementAtOrDefault(i) ?? string.Empty;
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