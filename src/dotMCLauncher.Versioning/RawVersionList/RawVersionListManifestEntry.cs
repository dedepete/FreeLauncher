using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class RawVersionListManifestEntry : Version
    {
        [JsonProperty("url")]
        public string ManifestUrl { get; set; }
    }
}