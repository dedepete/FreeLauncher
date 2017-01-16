using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class RawVersionListManifestLatest
    {
        [JsonProperty("release")]
        public string Release;
        [JsonProperty("snapshot")]
        public string Snapshot;
    }
}