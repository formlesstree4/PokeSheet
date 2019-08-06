using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PokeSheet
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        /*
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        */

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Static.Load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var args = Environment.GetCommandLineArgs();
            var frm = new FrmMain();

            // check
            if (args.Any() && args.Contains("/parse"))
                frm.EnableParsing();
            if (args.Any() && args.Contains("/console"))
                AllocConsole();
            
            Application.Run(frm);
            Application.ApplicationExit += (sender, eventArgs) => FreeConsole();
            Application.ThreadException += (sender, eventArgs) => Console.WriteLine(eventArgs.Exception.ToString());
        }
    }
}
