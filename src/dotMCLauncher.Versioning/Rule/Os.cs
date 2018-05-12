using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class Os
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
