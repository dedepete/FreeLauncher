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
        /// Последний использованный профиль.
        /// </summary>
        [JsonProperty("selectedProfile")]
        public string LastUsedProfile { get; set; }

        /// <summary>
        /// Список профилей.
        /// </summary>
        [JsonProperty("profiles")]
        public Dictionary<string, Profile> Profiles { get; set; }

        /// <summary>
        /// Парсинг профиля.
        /// </summary>
        /// <param name="pathToFile">Путь до файла с профилями.</param>
        public static ProfileManager ParseProfile(string pathToFile)
        {
            return (ProfileManager) JsonConvert.DeserializeObject(File.ReadAllText(pathToFile), typeof (ProfileManager));
        }

        /// <summary>
        /// Вывод файла профилей в формате JSON.
        /// </summary>
        public string ToJson()
        {
            return ToJson(Formatting.Indented, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Вывод файла профилей в формате JSON.
        /// </summary>
        /// <param name="formatting">Формат текста.</param>
        public string ToJson(Formatting formatting)
        {
            return ToJson(formatting, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Вывод файла профилей в формате JSON.
        /// </summary>
        /// <param name="formatting">Формат текста.</param>
        /// <param name="settings">Настройки сериалайзера.</param>
        public string ToJson(Formatting formatting, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
        }

        /// <summary>
        /// Добавление профиля в список.
        /// </summary>
        /// <param name="profile">Добавляемый профиль.</param>
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
        /// Удаление профиля из списка.
        /// </summary>
        /// <param name="profile">Удаляемый профиль.</param>
        public void DeleteProfile(Profile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new ArgumentNullException(nameof(profile.ProfileName));
            }
            Profiles.Remove(profile.ProfileName);
        }

        /// <summary>
        /// Переименование профиля в списке.
        /// </summary>
        /// <param name="profile">Профиль для переименования.</param>
        /// <param name="newName">Новое название профиля.</param>
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