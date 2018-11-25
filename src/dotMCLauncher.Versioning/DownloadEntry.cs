using Newtonsoft.Json;

namespace dotMCLauncher.Versioning
{
    public class DownloadEntry
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("sha1")]
        public string Sha1 { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonIgnore]
        public bool IsNative { get; set; }
    }
}
