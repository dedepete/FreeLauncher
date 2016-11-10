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
            return ToJson(Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Вывод файла профилей в формате JSON.
        /// </summary>
        /// <param name="formatting">Формат текста.</param>
        public string ToJson(Formatting formatting)
        {
            return ToJson(formatting, new JsonSerializerSettings()
            {
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
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        /// <summary>
        /// Добавление профиля в список.
        /// </summary>
        /// <param name="profile">Добавляемый профиль.</param>
        public void AddProfile(Profile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.ProfileName)) {
                throw new Exception("Field 'ProfileName' couldn't be empty");
            }
            if (Profiles.Keys.Contains(profile.ProfileName)) {
                throw new Exception("Profile '" + profile.ProfileName + "' already exist in list.");
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
                throw new Exception("Field 'ProfileName' couldn't be empty");
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

    public class Profile
    {
        /// <summary>
        /// Название профиля.
        /// </summary>
        [JsonProperty("name")] public string ProfileName;

        /// <summary>
        /// Рабочая директория для игры.
        /// </summary>
        [JsonProperty("gameDir")] public string WorkingDirectory;

        /// <summary>
        /// Выбранная версия для игры.
        /// </summary>
        [JsonProperty("lastVersionId")] public string SelectedVersion;

        /// <summary>
        /// Размер окна игры.
        /// </summary>
        [JsonProperty("resolution")] public MinecraftWindowSize WindowSize;

        /// <summary>
        /// Версии, которые будут выводиться в списке версий.
        /// </summary>
        [JsonProperty("allowedReleaseTypes")] public string[] AllowedReleaseTypes;

        /// <summary>
        /// Исполняемый файл Java.
        /// </summary>
        [JsonProperty("javaDir")] public string JavaExecutable;

        /// <summary>
        /// Аргументы Java.
        /// </summary>
        [JsonProperty("javaArgs")] public string JavaArguments;

        /// <summary>
        /// Сервер, к которому будет совершено подключение после запуска игры(не используется в официальном лаунчере).
        /// </summary>
        [JsonProperty("connectionOptions")] public ConnectionSettings FastConnectionSettigs;

        [JsonProperty("launcherVisibilityOnGameClose")] private string _launcherVisibilityOnGameClose;
        /// <summary>
        /// Состояние окна лаунчера при запуске игры.
        /// </summary>
        [JsonIgnore] public LauncherVisibility LauncherVisibilityOnGameClose
        {
            get
            {
                switch (_launcherVisibilityOnGameClose) {
                    case "hide launcher and re-open when game closes":
                        return LauncherVisibility.HIDDEN;
                    case "close launcher when game starts":
                        return LauncherVisibility.CLOSED;
                    default:
                        return LauncherVisibility.VISIBLE;
                }
            }
            set
            {
                switch (value) {
                    case LauncherVisibility.HIDDEN:
                        _launcherVisibilityOnGameClose = "hide launcher and re-open when game closes";
                        break;
                    case LauncherVisibility.CLOSED:
                        _launcherVisibilityOnGameClose = "close launcher when game starts";
                        break;
                    default:
                        _launcherVisibilityOnGameClose = "keep the launcher open";
                        break;
                }
            }
        }

        public enum LauncherVisibility
        {
            /// <summary>
            /// Keep the launcher open
            /// </summary>
            VISIBLE,

            /// <summary>
            /// Hide launcher and re-open when game closes
            /// </summary>
            HIDDEN,

            /// <summary>
            /// Close launcher when game starts
            /// </summary>
            CLOSED
        }

        /// <summary>
        /// Вывод профиля в JSON формате. 
        /// </summary>
        public string ToString(Formatting formatting = Formatting.None)
        {
            return JsonConvert.SerializeObject(this, formatting, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore

            });
        }

        /// <summary>
        /// Парсинг профиля из JSON текста. 
        /// </summary>
        /// <param name="json">JSON текст.</param>
        public static Profile ParseProfile(string json)
        {
            return JsonConvert.DeserializeObject<Profile>(json);
        }
    }

    public class MinecraftWindowSize
    {
        [JsonProperty("height")] public int Y = 480;
        [JsonProperty("width")] public int X = 854;

        /// <summary>
        /// Устанавливает значения по умолчанию.
        /// </summary>
        void SetDefaultValues()
        {
            Y = 480;
            X = 854;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
        /// <summary>
        /// Вывод как аргументы.
        /// </summary>
        public string ToCommandLineArg()
        {
            return $"--width {X} --height {Y}";
        }
    }

    public class ConnectionSettings
    {
        [JsonProperty("ip")] public string ServerIP;
        [JsonProperty("port")] public uint ServerPort = 25565;

        public string BuildIP()
        {
            return ServerIP + ":" + ServerPort;
        }

        public string BuildArguments()
        {
            return $"--server {ServerIP} --port {ServerPort}";
        }
    }
}