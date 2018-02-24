using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class OS
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
