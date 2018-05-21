using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling
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
        [JsonIgnore]
        public List<KeyValuePair<string, Profile>> Profiles { get; set; }

        [JsonProperty("profiles")]
        private Dictionary<string, Profile> _profiles
        {
            get {
                if (Profiles == null || !Profiles.Any()) {
                    return null;
                }
                return Profiles.ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            set {
                Profiles = value.ToList();
            }
        }

        /// <summary>
        /// Parses profiles. 
        /// </summary>
        /// <param name="pathToFile">Path to file with profiles data.</param>
        public static ProfileManager ParseProfile(string pathToFile)
        {
            return (ProfileManager) JsonConvert.DeserializeObject(File.ReadAllText(pathToFile), typeof(ProfileManager));
        }

        /// <summary>
        /// Returns profiles data in JSON format. 
        /// </summary>
        public string ToJson()
        {
            return ToJson(Formatting.Indented, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Returns profiles data in JSON format. 
        /// </summary>
        /// <param name="formatting">JSON formatting.</param>
        public string ToJson(Formatting formatting)
        {
            return ToJson(formatting, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public Profile GetProfile(string name)
        {
            return Profiles.First(pair => pair.Key == name).Value;
        }

        /// <summary>
        /// Returns profiles data in JSON format. 
        /// </summary>
        /// <param name="formatting">JSON formatting.</param>
        /// <param name="settings">Serializer settings.</param>
        public string ToJson(Formatting formatting, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        /// <summary>
        /// Adds profile into list. 
        /// </summary>
        /// <param name="profile">Profile.</param>
        public void AddProfile(Profile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new ArgumentNullException(nameof(profile.ProfileName));
            }
            if (Profiles.ToArray().Any(pair => pair.Key == profile.ProfileName)) {
                throw new ArgumentException("Profile '" + profile.ProfileName + "' already exists.");
            }
            Profiles.Add(new KeyValuePair<string, Profile>(profile.ProfileName, profile));
        }

        /// <summary>
        /// Removes profile from list. 
        /// </summary>
        /// <param name="profile">Profile.</param>
        public void RemoveProfile(Profile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new ArgumentNullException(nameof(profile.ProfileName));
            }
            Profiles.Remove(Profiles.First(pair => pair.Key == profile.ProfileName));
        }

        /// <summary>
        /// Removes profile from list. 
        /// </summary>
        /// <param name="profileName">Profile name.</param>
        public void RemoveProfile(string profileName)
        {
            if (string.IsNullOrWhiteSpace(profileName)) {
                throw new ArgumentNullException(nameof(profileName));
            }
            Profiles.Remove(Profiles.First(pair => pair.Key == profileName));
        }

        /// <summary>
        /// Renames profile in the list. 
        /// </summary>
        /// <param name="profile">Profile to rename.</param>
        /// <param name="newName">New name.</param>
        public void RenameProfile(Profile profile, string newName)
        {
            if (LastUsedProfile == profile.ProfileName) {
                LastUsedProfile = newName;
            }
            RemoveProfile(profile);
            profile.ProfileName = newName;
            AddProfile(profile);
        }

        public void MoveUpProfile(Profile profile)
        {
            ChangeProfilesOrder(profile, false);
        }

        public void MoveDownProfile(Profile profile)
        {
            ChangeProfilesOrder(profile, true);
        }

        private void ChangeProfilesOrder(Profile profile, bool moveDown)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new ArgumentNullException(nameof(profile.ProfileName));
            }
            if (Profiles.All(pair => pair.Key != profile.ProfileName)) {
                throw new ArgumentException("Profile '" + profile.ProfileName + "' does not exist.");
            }
            int index = Profiles.IndexOf(Profiles.First(pair => pair.Key == profile.ProfileName));
            if (index != 0 && moveDown) {
                Profiles.RemoveAt(index);
                Profiles.Insert(index - 1, new KeyValuePair<string, Profile>(profile.ProfileName, profile));
            }
            if (index != Profiles.Count - 1 && !moveDown) {
                Profiles.RemoveAt(index);
                Profiles.Insert(index + 1, new KeyValuePair<string, Profile>(profile.ProfileName, profile));
            }
        }
    }
}
