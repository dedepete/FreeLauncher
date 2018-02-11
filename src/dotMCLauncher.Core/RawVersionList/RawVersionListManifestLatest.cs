using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class RawVersionListManifestLatest
    {
        [JsonProperty("release")]
        public string Release { get; set; }

        [JsonProperty("snapshot")]
        public string Snapshot { get; set; }
    }
}
