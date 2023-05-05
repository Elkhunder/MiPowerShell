using PEFile;
using System.Security;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace MiPowerShell.Arguments.BiosCommands
{
    //public class BiosCommandArguments : CommandArguments
    //{
        //public SecureString? BiosPassword { get; set; }
        //public BiosCommandArguments(SecureString biosPassword, string[] computerNames, DialogResult remote, DialogResult local) : base(computerNames, remote, local)
        //{
        //    BiosPassword = biosPassword;
        //}

        //public void Deconstruct(out SecureString biosPassword, out string[] computerNames, out DialogResult remote, out DialogResult local)
        //{
        //    base.Deconstruct(out computerNames, out remote, out local);
        //    biosPassword = BiosPassword ?? throw new ArgumentNullException("A Bios Password is required", nameof(BiosPassword));
        //}
    //}
}
