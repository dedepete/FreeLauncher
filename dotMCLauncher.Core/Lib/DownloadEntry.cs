using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class DownloadEntry
    {
        [JsonProperty("path")]
        public string Path;
        [JsonProperty("url")]
        public string Url;
    }
}
