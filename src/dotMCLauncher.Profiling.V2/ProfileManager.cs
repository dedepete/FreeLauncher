using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class ProfileManager : Serializable
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
        public Dictionary<string, LauncherProfile> Profiles { get; set; }

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
        public Dictionary<string, AuthenticationEntry> AuthenticationDatabase { get; set; }

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
            foreach (KeyValuePair<string, LauncherProfile> pair in Profiles) {
                pair.Value.AssociatedId = pair.Key;
            }
        }

        public void AddProfile(LauncherProfile launcherProfile)
        {
            AddProfile(launcherProfile.Name, launcherProfile);
        }

        public void AddProfile(string id, LauncherProfile launcherProfile)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentNullException(nameof(id));
            }
            if (Profiles.Keys.Contains(id)) {
                throw new ArgumentException($"Profile with id '{id}' already exists.");
            }
            launcherProfile.AssociatedId = id;
            Profiles.Add(id, launcherProfile);
        }

        public void RemoveProfile(LauncherProfile launcherProfile)
        {
            RemoveProfile(launcherProfile.AssociatedId);
        }

        public void RemoveProfile(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentNullException(nameof(id));
            }
            Profiles.Remove(id);
        }

        public void ChangeProfileId(LauncherProfile launcherProfile, string newId)
        {
            ChangeProfileId(launcherProfile.AssociatedId, newId);
        }

        public void ChangeProfileId(string id, string newId)
        {
            Dictionary<string, LauncherProfile> newProfiles = new Dictionary<string, LauncherProfile>();
            foreach (KeyValuePair<string, LauncherProfile> pair in Profiles) {
                if (pair.Key != id) {
                    newProfiles.Add(pair.Key, pair.Value);
                    continue;
                }
                pair.Value.AssociatedId = newId;
                newProfiles.Add(newId, pair.Value);
            }
            Profiles = newProfiles;
        }

        public static ProfileManager ParseProfiles(string pathToFile)
        {
            return (ProfileManager)JsonConvert.DeserializeObject(File.ReadAllText(pathToFile), typeof(ProfileManager));
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            AssociateIds();
        }
    }
}
