using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Versioning
{
    public class Lib
    {
        /// <summary>
        /// Library's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Library's download info.
        /// </summary>
        [JsonProperty("downloads")]
        public LibDownloadInfo DownloadInfo { get; set; }

        /// <summary>
        /// Library's download URL. Not being used in official versions, but may be used by modded versions.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("natives")]
        private JObject _natives;

        [JsonProperty("rules")]
        private List<Rule> _rules;

        /// <summary>
        /// Returns processed library name if one's a native and supports Windows. Returns null, if not.
        /// </summary>
        [JsonIgnore]
        public string IsNative => _natives?["windows"]?.ToString().Replace("${arch}", IntPtr.Size == 8 ? "64" : "32");

        /// <summary>
        /// Returns True if library supports Windows operating system.
        /// </summary>
        public bool IsForWindows()
        {
            if (_rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in _rules) {
                switch (rule.Action) {
                    case "allow":
                        toReturn = (rule.Os == null && rule.Features == null) || rule.Os.Name == "windows";
                        break;
                    case "disallow":
                        toReturn = (rule.Os == null && rule.Features == null) ? toReturn : rule.Os.Name != "windows";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rule.Action), rule.Action, null);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Returns path to library.
        /// </summary>
        public string GetPath()
        {
            string[] s = Name.Split(':');
            return string.Format(@"{0}\{1}\{2}\{1}-{2}" +
                (!string.IsNullOrEmpty(IsNative) ? "-" + IsNative : string.Empty) + ".jar",
                s[0].Replace('.', '\\'), s[1], s[2]);
        }

        /// <summary>
        /// Returns full URL. Null if Url is not presented.
        /// </summary>
        public string GetUrl()
        {
            return Url != null ? Url += GetPath() : null;
        }
    }
}
