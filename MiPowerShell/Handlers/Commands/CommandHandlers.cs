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
                { "Add-Shortcut", new AddShortcutHandler() },
                { "Clear-BiosPassword", new ClearBiosPasswordHandler() },
                { "Get-CurrentUser", new GetCurrentUserHandler() },
                { "Get-HardDriveSerial", new GetHardDriveSerialHandler() },
                { "Get-Printers", new GetPrintersHandler() },
                { "Get-UserProfile", new GetUserProfileHandler() },
                { "Get-WindowsVersion", new GetWindowsVersionHandler() },
                { "Install-Language", new InstallLanguageHandler() },
                { "Remove-UserProfile", new RemoveUserProfileHandler() },
                { "Set-BiosPassword", new SetBiosPasswordHandler() },
                { "Set-NetworkProfile", new SetNetworkProfileHandler() },
                { "Set-PrinterName", new SetPrinterNameHandler() },
                { "Set-Printers", new SetPrintersHandler() },
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
