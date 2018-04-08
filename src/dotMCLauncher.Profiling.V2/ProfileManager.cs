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

        public void AddProfile(Profile profile)
        {
            AddProfile(profile.Name, profile);
        }

        public void AddProfile(string id, Profile profile)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentNullException(nameof(id));
            }
            if (Profiles.Keys.Contains(id)) {
                throw new ArgumentException($"Profile with id '{id}' already exists.");
            }
            profile.AssociatedId = id;
            Profiles.Add(id, profile);
        }

        public void RemoveProfile(Profile profile)
        {
            RemoveProfile(profile.AssociatedId);
        }

        public void RemoveProfile(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) {
                throw new ArgumentNullException(nameof(id));
            }
            Profiles.Remove(id);
        }

        public void ChangeProfileId(Profile profile, string newId)
        {
            ChangeProfileId(profile.AssociatedId, newId);
        }

        public void ChangeProfileId(string id, string newId)
        {
            Dictionary<string, Profile> newProfiles = new Dictionary<string, Profile>();
            foreach (KeyValuePair<string, Profile> pair in Profiles) {
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
