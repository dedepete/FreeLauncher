using Newtonsoft.Json;

namespace dotMCLauncher.Profiling
{
    public class WindowInfo
    {
        [JsonProperty("height")]
        public int Height { get; set; } = 480;

        [JsonProperty("width")]
        public int Width { get; set; } = 854;

        /// <summary>
        /// Resets values.
        /// </summary>
        public void SetDefaultValues()
        {
            Height = 480;
            Width = 854;
        }

        public override string ToString()
        {
            return $"({Width};{Height})";
        }

        /// <summary>
        /// Returns command line arguments.
        /// </summary>
        public string ToCommandLineArg()
        {
            return $"--width {Width} --height {Height}";
        }
    }
}
