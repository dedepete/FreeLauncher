using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
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
            if (Profiles.Keys.Contains(profile.ProfileName)) {
                throw new ArgumentException("Profile '" + profile.ProfileName + "' already exists.");
            }
            Profiles.Add(profile.ProfileName, profile);
        }

        /// <summary>
        /// Removes profile from list. 
        /// </summary>
        /// <param name="profile">Profile.</param>
        public void DeleteProfile(Profile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new ArgumentNullException(nameof(profile.ProfileName));
            }
            Profiles.Remove(profile.ProfileName);
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
            Profiles.Remove(profile.ProfileName);
            profile.ProfileName = newName;
            Profiles[newName] = profile;
        }
    }
}
