using MiPowerShell.Handlers;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace MiPowerShell.Helpers.Managers
{
    public class FirewallManager : PowerShellAPI
    {
        private string? _deviceName;
        public FirewallManager(int maxRunspaces, string deviceName)
        : base(RunspaceFactory.CreateRunspacePool(1, maxRunspaces), deviceName)
        {
            this.RunspacePool.Open();
            this._deviceName = deviceName;
        }

        public FirewallManager(int maxRunspaces)
        : base(RunspaceFactory.CreateRunspacePool(1, maxRunspaces))
        {
            this.RunspacePool.Open();
        }

        public Collection<PSObject> GetFirewallRules()
        {
            var command = new PSCommand();
            command.AddCommand("Get-NetFirewallRule");
            return RunPowerShell(command);
        }

        public Collection<PSObject> NewFirewallRule(string name, string protocol, string localPort)
        {
            var command = new PSCommand();
            command.AddCommand("New-NetFirewallRule");
            command.AddParameter("DisplayName", name);
            command.AddParameter("Protocol", protocol);
            command.AddParameter("LocalPort", localPort);
            return RunPowerShell(command);
        }

        public Collection<PSObject> SetFirewallRule(string name, string newStatus)
        {
            var command = new PSCommand();
            command.AddCommand("Set-NetFirewallRule");
            command.AddParameter("DisplayName", name);
            command.AddParameter("Enabled", newStatus);
            return RunPowerShell(command);
        }

        public Collection<PSObject> DeleteFirewallRule(string name)
        {
            var command = new PSCommand();
            command.AddCommand("Remove-NetFirewallRule");
            command.AddParameter("DisplayName", name);
            return RunPowerShell(command);
        }

        public Collection<PSObject> GetSpecificFirewallRule(string name)
        {
            var command = new PSCommand();
            command.AddCommand("Get-NetFirewallRule");
            command.AddParameter("DisplayName", name);
            return RunPowerShell(command);
        }

        public Collection<PSObject> BlockAllInboundTraffic()
        {
            var command = new PSCommand();
            command.AddCommand("Set-NetFirewallProfile");
            command.AddParameter("DefaultInboundAction", "Block");
            return RunPowerShell(command);
        }

        public Collection<PSObject> AllowAllInboundTraffic()
        {
            var command = new PSCommand();
            command.AddCommand("Set-NetFirewallProfile");
            command.AddParameter("DefaultInboundAction", "Allow");
            return RunPowerShell(command);
        }

        public Collection<PSObject> EnableFirewall()
        {
            var command = new PSCommand();
            command.AddCommand("Set-NetFirewallProfile");
            command.AddParameter("Enabled", "True");
            return RunPowerShell(command);
        }

        public Collection<PSObject> DisableFirewall()
        {
            var command = new PSCommand();
            command.AddCommand("Set-NetFirewallProfile");
            command.AddParameter("Enabled", "False");
            return RunPowerShell(command);
        }

        public Collection<PSObject> GetFirewallProfiles()
        {
            var command = new PSCommand();
            command.AddCommand("Get-NetFirewallProfile");
            return RunPowerShell(command);
        }
    }
}
