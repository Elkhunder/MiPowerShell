using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace MiPowerShell
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AdminLauncher();
                //only admins can run this wizard
                if (IsAdmin())
                {
                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
                    Application.Run(new Form1());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        private static void AdminLauncher()
        {
            if (!IsAdmin())
            {
                ProcessStartInfo proc = new()
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };
                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    // If dont want to lauch application as admin or do not have permissions
                    return;
                }
                Environment.Exit(0); // Quit itself
            }
        }
        // check if application is lauched with admin permissions.
        private static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}