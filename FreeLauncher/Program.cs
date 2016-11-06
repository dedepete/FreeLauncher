using System;
using System.Windows.Forms;
using FreeLauncher.Forms;
using Telerik.WinControls;

namespace FreeLauncher
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var applicationContext = new ApplicationContext(args);
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm(applicationContext));
            applicationContext.SaveConfiguration();
        }
    }
}