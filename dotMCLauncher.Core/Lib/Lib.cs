using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Core
{
    public class Lib
    {
        /// <summary>
        /// Название библиотеки.
        /// </summary>
        [JsonProperty("name")]
        public string Name;

        /// <summary>
        /// Информация для загрузки файла.
        /// </summary>
        [JsonProperty("downloads")]
        public DownloadInfo DownloadInfo;

        [JsonProperty("natives")]
        private JObject _natives;
        [JsonProperty("rules")]
        private List<Rule> Rules;

        /// <summary>
        /// Возвращает значение, которое добавляется в обработанное название библиотеки, если библиотека поддерживается Windows и является архивом, который содержит необходимые для игры DLL. Если нет, то возвращает null.
        /// </summary>
        [JsonIgnore]
        public string IsNative => _natives?["windows"]?.ToString().Replace("${arch}", IntPtr.Size == 8 ? "64" : "32");

        /// <summary>
        /// Возвращает True, если библиотека поддерживается Windows.
        /// </summary>
        public bool IsForWindows()
        {
            if (Rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in Rules) {
                switch (rule.action) {
                    case "allow":
                        toReturn = rule.os == null || rule.os["name"].ToString() == "windows";
                        break;
                    case "disallow":
                        toReturn = rule.os == null ? toReturn : rule.os["name"].ToString() != "windows";
                        break;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Возвращает путь к библиотеке.
        /// </summary>
        /// <param name="generate">При True генерирует значение из названия библиотеки.</param>
        /// <param name="os">Требуемая операционная система.</param>
        public string GetPath(bool generate = false, OperatingSystem os = OperatingSystem.OTHER)
        {
            string[] s = Name.Split(':');
            return (generate || DownloadInfo == null)
                ? string.Format("{0}\\{1}\\{2}\\{1}-{2}" +
                                (!string.IsNullOrEmpty(IsNative) ? "-" + IsNative : string.Empty) + ".jar",
                    s[0].Replace('.', '\\'), s[1], s[2])
                : DownloadInfo.GetDownloadsEntry(os).Path;
        }

        /// <summary>
        /// Возвращает путь к библиотеке.
        /// </summary>
        /// <param name="os">Требуемая операционная система.</param>
        public string GetPath(OperatingSystem os)
        {
            return GetPath(false, os);
        }
    }
}
