using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class VersionDownloadInfo
    {
        [JsonProperty("client")]
        public DownloadEntry Client { get; set; }

        [JsonProperty("server")]
        public DownloadEntry Server { get; set; }

        [JsonIgnore]
        public bool IsServerAvailable => Server != null;
    }
}
