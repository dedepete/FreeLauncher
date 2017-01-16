using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class RawVersionListManifestEntry : Version
    {
        [JsonProperty("url")]
        public string ManifestUrl;
    }
}