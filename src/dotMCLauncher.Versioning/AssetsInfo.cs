using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class AssetsInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
