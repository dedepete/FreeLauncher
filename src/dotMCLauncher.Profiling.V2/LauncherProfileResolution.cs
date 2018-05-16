using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class LauncherProfileResolution : Serializable
    {
        [JsonProperty("width")]
        public int Width { get; set; } = 854;

        [JsonProperty("height")]
        public int Height { get; set; } = 481;
    }
}