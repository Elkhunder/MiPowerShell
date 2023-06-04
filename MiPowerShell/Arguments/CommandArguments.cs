using System.Security;
namespace MiPowerShell.Arguments
{
    public record CommandArguments
    {
        public SecureString? BiosPassword { get; init; }
        public string? PrinterName { get; init; }
        public string? NewPrinterName { get; init; }
        public SecureString? NewBiosPassword { get; init; }
        public string[] ComputerNames { get; init; }
        public string UserName { get; init; }

        public CommandArguments(SecureString biosPassword, SecureString newBiosPassword, string[] computerNames, string printerName, string newPrinterName, string userName)
        {
            BiosPassword = biosPassword;
            NewBiosPassword = newBiosPassword;
            ComputerNames = computerNames;
            PrinterName = printerName;
            NewPrinterName = newPrinterName;
            UserName = userName;
        }

        public void Deconstruct(out string[] computerNames, out SecureString biosPassword)
        {
            computerNames = ComputerNames;
            biosPassword = BiosPassword;
        }

        public void Deconstruct(out string[] computerNames, out SecureString biosPassword, out SecureString newBiosPassword)
        {
            computerNames = ComputerNames;
            biosPassword = BiosPassword;
            newBiosPassword = NewBiosPassword;
        }

        public void Deconstruct(out string[] computerNames, out string printerName, out string newPrinterName, out SecureString biosPassword)
        {
            computerNames = ComputerNames;
            printerName = PrinterName;
            newPrinterName = NewPrinterName;
            biosPassword = BiosPassword;
        }
    }
}
