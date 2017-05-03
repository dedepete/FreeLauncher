using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class VersionDownloadInfo
    {
        [JsonProperty("client")] public DownloadEntry Client;
        [JsonProperty("server")] public DownloadEntry Server;

        [JsonIgnore]
        public bool IsServerAvailable => Server != null;
    }
}