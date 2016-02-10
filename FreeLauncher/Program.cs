using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using CommandLine;
using FreeLauncher.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telerik.WinControls;

namespace FreeLauncher
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments(args, Variables.ProgramArguments);
            InitValues();

            var configuration = GetConfiguration();
            Variables.SetLocalization(configuration.SelectedLanguage);
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm(ref configuration));
            File.WriteAllText(Variables.McLauncher + "\\configuration.json",
                JsonConvert.SerializeObject(configuration, Formatting.Indented));
        }

        public static void InitValues()
        {
            Variables.McDirectory = Variables.ProgramArguments.WorkingDirectory ??
                                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                        ".minecraft\\");
            Variables.McLauncher = Path.Combine(Variables.McDirectory, "freelauncher\\");
            Variables.McVersions = Path.Combine(Variables.McDirectory, "versions\\");
            Variables.McLibs = Path.Combine(Variables.McDirectory, "libraries\\");
        }

        private static Configuration GetConfiguration()
        {
            var configurationFile = Variables.McLauncher + "\\configuration.json";
            if (File.Exists(configurationFile))
                return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configurationFile));

            return new Configuration();
        }
    }
}