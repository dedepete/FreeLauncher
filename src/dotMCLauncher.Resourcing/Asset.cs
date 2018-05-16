using Newtonsoft.Json;

namespace dotMCLauncher.Resourcing
{
    public class Asset
    {
        [JsonIgnore]
        public string AssociatedName { get; set; }

        [JsonProperty("hash")]
        public AssetHash Hash { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
