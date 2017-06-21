using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Core
{
    public class Lib
    {
        /// <summary>
        /// Library's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name;

        /// <summary>
        /// Library's download info.
        /// </summary>
        [JsonProperty("downloads")]
        public LibDownloadInfo DownloadInfo;

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
                switch (rule.action) {
                    case "allow":
                        toReturn = rule.os == null || rule.os["name"].ToString() == "windows";
                        break;
                    case "disallow":
                        toReturn = rule.os == null ? toReturn : rule.os["name"].ToString() != "windows";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rule.action), rule.action, null);
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
    }
}
