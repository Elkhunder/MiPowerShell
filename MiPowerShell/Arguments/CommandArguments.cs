using System.Security;
namespace MiPowerShell.Arguments
{
    public class CommandArguments
    {
        public SecureString BiosPassword { get; set; }

        public SecureString NewBiosPassword { get; set; }
        public string[]? ComputerNames { get; set; }
        public DialogResult? Remote { get; set; }
        public DialogResult? Local { get; set; }

        public CommandArguments(SecureString biosPassword, SecureString newBiosPassword, string[] computerNames, DialogResult remote, DialogResult local)
        {
            BiosPassword = biosPassword;
            NewBiosPassword = newBiosPassword;
            ComputerNames = computerNames;
            Remote = remote;
            Local = local;
        }

        public void Deconstruct(out SecureString biosPassword, out SecureString newBiosPassword, out string[] computerNames, out DialogResult remote, out DialogResult local)
        {
            biosPassword = BiosPassword;
            newBiosPassword = NewBiosPassword;
            computerNames = ComputerNames;
            remote = Remote.GetValueOrDefault();
            local = Local.GetValueOrDefault();
        }
    }
}
