using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class WindowInfo
    {
        [JsonProperty("height")] public int Y { get; set; } = 480;
        [JsonProperty("width")] public int X { get; set; } = 854;

        /// <summary>
        /// Resets values.
        /// </summary>
        public void SetDefaultValues()
        {
            Y = 480;
            X = 854;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }

        /// <summary>
        /// Returns command line arguments.
        /// </summary>
        public string ToCommandLineArg()
        {
            return $"--width {X} --height {Y}";
        }
    }
}
