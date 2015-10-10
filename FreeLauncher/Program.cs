using System;
using System.IO;
using System.Windows.Forms;
using CommandLine;
using FreeLauncher.Forms;
using Newtonsoft.Json;
using Telerik.WinControls;

namespace FreeLauncher
{
    internal class Program
    {
        private static Configuration _cfg;

        [STAThread]
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments(args, Variables.ProgramArguments);
            InitValues();
            _cfg = File.Exists(Variables.McLauncher + "\\configuration.json")
                ? JsonConvert.DeserializeObject<Configuration>(
                    File.ReadAllText(Variables.McLauncher + "\\configuration.json"))
                : new Configuration();
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm(ref _cfg));
            File.WriteAllText(Variables.McLauncher + "\\configuration.json",
                JsonConvert.SerializeObject(_cfg, Formatting.Indented));
        }

        public static void InitValues()
        {
            //TODO: Localization
            //File.WriteAllText(Variables.McLauncher + "\\local.json", JsonConvert.SerializeObject(Variables.ProgramLocalization, Formatting.Indented));
            //Variables.ProgramLocalization = JsonConvert.DeserializeObject<Localization>(File.ReadAllText(Variables.McLauncher + "\\lang.en-UK.json"));
            Variables.McDirectory = Variables.ProgramArguments.WorkingDirectory ??
                                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                        ".minecraft\\");
            Variables.McLauncher = Path.Combine(Variables.McDirectory, "freelauncher\\");
            Variables.McVersions = Path.Combine(Variables.McDirectory, "versions\\");
            Variables.McLibs = Path.Combine(Variables.McDirectory, "libraries\\");
        }
    }
}