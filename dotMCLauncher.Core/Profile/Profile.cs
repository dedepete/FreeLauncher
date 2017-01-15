using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
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
        [JsonProperty("resolution")] public WindowInfo WindowInfo;

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
        [JsonProperty("connectionOptions")] public ServerInfo FastConnectionSettigs;

        [JsonProperty("launcherVisibilityOnGameClose")] private string _launcherVisibilityOnGameClose;

        /// <summary>
        /// Состояние окна лаунчера при запуске игры.
        /// </summary>
        [JsonIgnore]
        public LauncherVisibility LauncherVisibilityOnGameClose
        {
            get {
                switch (_launcherVisibilityOnGameClose) {
                    case "hide launcher and re-open when game closes":
                        return LauncherVisibility.HIDDEN;
                    case "close launcher when game starts":
                        return LauncherVisibility.CLOSED;
                    default:
                        return LauncherVisibility.VISIBLE;
                }
            }
            set {
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
            return JsonConvert.SerializeObject(this, formatting, new JsonSerializerSettings {
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
}
