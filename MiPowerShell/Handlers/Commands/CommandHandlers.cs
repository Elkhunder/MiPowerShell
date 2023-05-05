using MiPowerShell.Helpers;
namespace MiPowerShell.Handlers.Commands
{
    internal class CommandHandlers
    {
        private readonly Dictionary<string, ICommandHandler> _handlers;
        public CommandHandlers()
        {
            _handlers = new Dictionary<string, ICommandHandler>
            {
                { "Clear-BiosPassword", new ClearBiosPasswordHandler() },
                { "Remove-UserProfile", new RemoveUserProfileHandler() },
                { "Set-BiosPassword", new SetBiosPasswordHandler() },
                { "Get-HardDriveSerial", new GetHardDriveSerialHandler() },
                { "Get-Printers", new GetPrintersHandler() },
                { "Install-Language", new InstallLanguageHandler() },
                { "Rename-Printers", new RenamePrintersHandler() },
                { "Set-NetworkProfile", new SetNetworkProfileHandler() },
                { "Set-Printers", new SetPrintersHandler() },
                { "Get-CurrentUser", new GetCurrentUserHandler() },
                { "Get-UserProfile", new GetUserProfileHandler() },
                { "Add-Shortcut", new AddShortcutHandler() },
                { "Uninstall-Software", new UninstallSoftwareHandler() }
            };
        }
        public ICommandHandler GetHandler(string command)
        {
            try
            {
                if (!_handlers.ContainsKey(command))
                {
                    Console.WriteLine($"Invalid Command Name: {command}");
                    throw new ArgumentException("Invalid command", nameof(command));
                }
            }
            catch (Exception ex)
            {

                // TODO: Handle exception in error handler
                Console.WriteLine(ex.ToString());
            }
            return _handlers[command];
        }
    }
}
