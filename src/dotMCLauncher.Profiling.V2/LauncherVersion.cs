using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class LauncherVersion : Serializable
    {
        [JsonProperty("name")]
        public string Version { get; set; } = "2.0.1003";

        [JsonProperty("format")]
        public int Format { get; set; } = 21;

        [JsonProperty("versionFormat")]
        public int VersionFormat { get; set; } = 2;
    }
}