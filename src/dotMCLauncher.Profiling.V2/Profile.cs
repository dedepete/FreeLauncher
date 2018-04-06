using System;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class Profile
    {
        [JsonIgnore]
        public string AssociatedName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // TODO: enum with all possible icons.
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("type")]
        private string _type { get; set; }

        [JsonIgnore]
        public ProfileType Type
        {
            get {
                switch (_type)
                {
                    case "latest-release":
                        return ProfileType.LATEST_RELEASE;
                    case "latest-snapshot":
                        return ProfileType.LATEST_SNAPSHOT;
                    default:
                        return ProfileType.CUSTOM;
                }
            }
            set {
                switch (value)
                {
                    case ProfileType.LATEST_RELEASE:
                        _type = "latest-release";
                        break;
                    case ProfileType.LATEST_SNAPSHOT:
                        _type = "latest-snapshot";
                        break;
                    default:
                        _type = "custom";
                        break;
                }
            }
        }

        [JsonProperty("lastVersionId")]
        public string SelectedVersion { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);

        [JsonProperty("lastUsed")]
        public DateTime LastUsed { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);

        [JsonProperty("gameDir")]
        public string GameDirectory { get; set; }
    }
}
