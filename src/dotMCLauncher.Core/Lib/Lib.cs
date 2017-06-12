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
        public LibDownloadInfo DownloadInfo;

        [JsonProperty("natives")]
        private JObject _natives;
        [JsonProperty("rules")]
        private List<Rule> _rules;

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
            if (_rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in _rules) {
                switch (rule.action) {
                    case "allow":
                        toReturn = rule.os == null || rule.os["name"].ToString() == "windows";
                        break;
                    case "disallow":
                        toReturn = rule.os == null ? toReturn : rule.os["name"].ToString() != "windows";
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected value: {rule.action}");
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Возвращает путь к библиотеке.
        /// </summary>
        public string GetPath()
        {
            string[] s = Name.Split(':');
            return string.Format("{0}\\{1}\\{2}\\{1}-{2}" +
                                 (!string.IsNullOrEmpty(IsNative) ? "-" + IsNative : string.Empty) + ".jar",
                s[0].Replace('.', '\\'), s[1], s[2]);
        }
    }
}
