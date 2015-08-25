using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FreeLauncher_Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TODO: Make this code better
            Console.WriteLine("FreeLauncher downloader v.0.2.1\n");
            Console.Title = "FreeLauncher downloader v.0.2.1";
            CommandLine.Parser.Default.ParseArguments(args, Variables.ProgramArguments);
            InitValues();
            ConsoleIO.WriteColored("Getting remote file list... ", ConsoleColor.DarkGray);
            string json = (Variables.ProgramArguments.CustomFilesList == null
                ? new WebClient().DownloadString(@"http://file.ru-minecraft.ru/freelauncher/frlu.json")
                : File.ReadAllText(Variables.ProgramArguments.CustomFilesList)).Replace("$InsDir$", Variables.McDirectory);
            ConsoleIO.WriteColoredLine("[OK]", ConsoleColor.DarkGreen);
            bool skip = !File.Exists(Variables.McLauncher + "/files.json");
            JObject jo = JObject.Parse(json.Replace(@"\", @"\\")), files = new JObject();
            string argTemp = string.Empty;
            if (Variables.ProgramArguments.ForcedSkip) {
                for (int i = 0; i != args.Length; i++)
                {
                    argTemp += args[i] + " ";
                }
                Process.Start(jo["executable"].ToString(), argTemp);
                return;
            }
            if (!skip) {
                files =
                    JObject.Parse(File.ReadAllText(Path.Combine(Variables.McLauncher, "files.json")));
            }
            if (Variables.ProgramArguments.ForcedUpdate) {
                ConsoleIO.WriteColoredLine("FORCED UPDATING IN PROGRESS!", ConsoleColor.Red);
            }
            foreach (JObject a in jo["files"]) {
                string path = a["path"].ToString().Replace("$File$", a["file"].ToString());
                if (!Directory.Exists(Path.GetDirectoryName(path))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    skip = true;
                }
                ConsoleIO.WriteColored(a["file"] + " " + a["version"] + " ", ConsoleColor.DarkGray);
                if (!skip && !Variables.ProgramArguments.ForcedUpdate)
                {
                    if (files?[a["file"].ToString()] != null) {
                        if (files[a["file"].ToString()]["version"].ToString() == a["version"].ToString()) {
                            ConsoleIO.WriteColoredLine("[OK]", ConsoleColor.DarkGray);
                            continue;
                        }
                    }
                }
                ConsoleIO.WriteColoredLine("[Fail]", ConsoleColor.DarkRed);
                Console.Write("Downloading... ");
                new WebClient().DownloadFile(a["url"].ToString().Replace("$File$", a["file"].ToString()), path);
                if (files[a["file"].ToString()] == null) {
                    files.Add(new JProperty(a["file"].ToString(), a));
                } else {
                    files[a["file"].ToString()] = a;
                }
                ConsoleIO.WriteColoredLine("[OK]", ConsoleColor.DarkGreen);
            }
            files["executable"] = jo["executable"];
            File.WriteAllText(Path.Combine(Variables.McDirectory, "freelauncher", "files.json"), files.ToString());
            UpdateVersionList();
            ConsoleIO.WriteColoredLine("Launching...", ConsoleColor.DarkGray);
            for (int i = 0; i != args.Length; i++) {
                argTemp += args[i] + " ";
            }
            argTemp += "--not-a-standalone";
            Process.Start(jo["executable"].ToString(), argTemp);
        }

        private static void UpdateVersionList()
        {
            Console.WriteLine("Checking version.json...");
            string jsonVersionList = new WebClient().DownloadString(
                new Uri("https://s3.amazonaws.com/Minecraft.Download/versions/versions.json"));
            if (!Directory.Exists(Variables.McVersions)) {
                Directory.CreateDirectory(Variables.McVersions);
            }
            if (!File.Exists(Variables.McVersions + "\\versions.json") || Variables.ProgramArguments.ForcedUpdate) {
                File.WriteAllText(Variables.McVersions + "\\versions.json", jsonVersionList);
                return;
            }
            JObject jb =
                JObject.Parse(jsonVersionList);
            string remoteSnapshotVersion = jb["latest"]["snapshot"].ToString();
            ConsoleIO.WriteColoredLine("Latest snapshot: " + remoteSnapshotVersion, ConsoleColor.DarkGray);
            string remoteReleaseVersion = jb["latest"]["release"].ToString();
            ConsoleIO.WriteColoredLine("Latest release: " + remoteReleaseVersion, ConsoleColor.DarkGray);
            JObject ver = JObject.Parse(File.ReadAllText(Variables.McVersions + "/versions.json"));
            string localSnapshotVersion = ver["latest"]["snapshot"].ToString();
            string localReleaseVersion = ver["latest"]["release"].ToString();
            Console.WriteLine("Local versions: " + ((JArray) jb["versions"]).Count + ". Remote versions: " +
                              ((JArray) ver["versions"]).Count);
            if (((JArray) jb["versions"]).Count == ((JArray) ver["versions"]).Count &&
                remoteReleaseVersion == localReleaseVersion && remoteSnapshotVersion == localSnapshotVersion) {
                Console.WriteLine("No update found.");
                return;
            }
            Console.Write("Writting new list... ");
            File.WriteAllText(Variables.McVersions + "\\versions.json", jsonVersionList);
            ConsoleIO.WriteColoredLine("[OK]", ConsoleColor.DarkGreen);
        }

        public static void InitValues()
        {
            Variables.McDirectory = Variables.ProgramArguments.WorkingDirectory ??
                                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                        ".minecraft\\");
            Variables.McLauncher = Path.Combine(Variables.McDirectory, "freelauncher\\");
            Variables.McVersions = Path.Combine(Variables.McDirectory, "versions\\");
        }
    }
}
