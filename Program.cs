using System;
using System.Windows.Forms;

namespace GitIgnoreExecutor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Useful snippet if I ever need it
            //WindowsIdentity identity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal principal = new WindowsPrincipal(identity);
            //if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            //{
            //    MessageBox.Show("Bu program yönetici olarak çalıştırılmak zorundadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    // Exiting the application does not return and vice versa so do both
            //    Application.Exit();
            //    return;
            //}

            Application.Run(new Form1());
        }
    }
}
