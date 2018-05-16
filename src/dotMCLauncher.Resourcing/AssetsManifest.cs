using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace dotMCLauncher.Resourcing
{
    public class AssetsManifest
    {
        [JsonProperty("virtual", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsVirtual { get; set; }

        [JsonProperty("objects")]
        public Dictionary<string, Asset> Objects { get; set; }

        public void AssociateNames()
        {
            foreach (KeyValuePair<string, Asset> pair in Objects) {
                pair.Value.AssociatedName = pair.Key;
            }
        }

        public static AssetsManifest Parse(string pathToFile)
        {
            return (AssetsManifest) JsonConvert.DeserializeObject(File.ReadAllText(pathToFile), typeof(AssetsManifest));
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            AssociateNames();
        }
    }
}
