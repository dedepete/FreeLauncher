using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class ProfileManager
    {
        /// <summary>
        /// Last used profile. 
        /// </summary>
        [JsonProperty("selectedProfile")]
        public string LastUsedProfile { get; set; }

        /// <summary>
        /// Profile list. 
        /// </summary>
        [JsonProperty("profiles")]
        public Dictionary<string, Profile> Profiles { get; set; }

        /// <summary>
        /// Launcher settings. 
        /// </summary>
        [JsonProperty("settings")]
        public Dictionary<string, object> Settings { get; set; }

        /// <summary>
        /// Launcher version. 
        /// </summary>
        [JsonProperty("launcherVersion")]
        public LauncherVersion LauncherVersion { get; set; }

        /// <summary>
        /// Authentication database. 
        /// </summary>
        [JsonProperty("authenticationDatabase")]
        public Dictionary<string, object> AuthenticationDatabase { get; set; }

        /// <summary>
        /// Last used entry from authentication database. 
        /// </summary>
        [JsonProperty("selectedUser")]
        public SelectedUser SelectedUser { get; set; }

        /// <summary>
        /// Analytics token. I don't like analytics. Why do u even need this field?
        /// </summary>
        [JsonProperty("analyticsToken")]
        public string AnalyticsToken { get; set; }

        /// <summary>
        /// Analytics failcount. Mojang are watching us!
        /// </summary>
        [JsonProperty("analyticsFailcount")]
        public int AnalyticsFailcount { get; set; }

        /// <summary>
        /// Client token.
        /// </summary>
        [JsonProperty("clientToken")]
        public string SessionToken { get; set; }

        private void AssociateIds()
        {
            foreach (KeyValuePair<string, Profile> pair in Profiles) {
                pair.Value.AssociatedId = pair.Key;
            }
        }

        public static ProfileManager ParseProfiles(string pathToFile)
        {
            return (ProfileManager) JsonConvert.DeserializeObject(File.ReadAllText(pathToFile), typeof(ProfileManager));
        }

        public string ToJson()
        {
            return ToJson(Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string ToJson(Formatting formatting)
        {
            return ToJson(formatting, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string ToJson(Formatting formatting, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        [OnDeserialized]
        internal void OnSerializedMethod(StreamingContext context)
        {
            AssociateIds();
        }
    }
}
