using System;
using System.IO;
using CommandLine;

namespace FreeLauncher_Launcher
{
    public static class Variables
    {
        public static Arguments ProgramArguments = new Arguments();

        public static string McDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft\\");
        public static string McLauncher = Path.Combine(McDirectory, "freelauncher\\");
        public static string McVersions = Path.Combine(McDirectory, "versions\\");
    }

    public class Arguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }
        [Option("custom-files-list")]
        public string CustomFilesList { get; set; }
        [Option("forced-update")]
        public bool ForcedUpdate { get; set; }
        [Option("forced-skip")]
        public bool ForcedSkip { get; set; }
    }
}
