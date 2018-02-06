using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class OS
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}