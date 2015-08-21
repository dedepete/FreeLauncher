using System;
using System.IO;
using CommandLine;

namespace FreeLauncher
{
    public static class Variables
    {
        public static Arguments ProgramArguments = new Arguments();

        public static string McDirectory = ProgramArguments.WorkingDirectory ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
        public static string McLauncher = Path.Combine(McDirectory, "freelauncher\\");
        public static string McVersions = Path.Combine(McDirectory, "versions\\");
        public static string McLibs = Path.Combine(McDirectory, "libraries\\");

        public static string LastSnapshotVersion = "15w33c";
        public static string LastReleaseVersion = "1.8.8";

        public static string Libraries = string.Empty;
    }

    public class Arguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }
        [Option("not-a-standalone")]
        public bool NotAStandalone { get; set; }
    }
}
