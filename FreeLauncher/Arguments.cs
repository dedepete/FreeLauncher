using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace FreeLauncher
{
    public class Arguments
    {
        [Option('d', "working-directory")]
        public string WorkingDirectory { get; set; }
        [Option("not-a-standalone")]
        public bool NotAStandalone { get; set; }
    }
}
