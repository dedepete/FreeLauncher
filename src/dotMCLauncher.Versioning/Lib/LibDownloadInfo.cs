using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using dotMCLauncher;

namespace dotMCLauncher.Versioning
{
    public class LibDownloadInfo
    {
        [JsonProperty("classifiers")]
        public Dictionary<string, DownloadEntry> Classifiers { get; set; }

        [JsonProperty("artifact")]
        public DownloadEntry Artifact { get; set; }

        [JsonIgnore]
        public Lib ParentLib { get; set; }

        public List<DownloadEntry> GetDownloadsEntries(OperatingSystem os)
        {
            List<DownloadEntry> result = new List<DownloadEntry>();
            if (os == OperatingSystem.OTHER || Classifiers == null) {
                result.Add(Artifact);
                return result;
            }
            result.Add(Artifact);
            string dictEntry;
            switch (os) {
                case OperatingSystem.WINDOWS:
                    dictEntry = "natives-windows";
                    break;
                case OperatingSystem.LINUX:
                    dictEntry = "natives-linux";
                    break;
                case OperatingSystem.MACOS:
                    dictEntry = "natives-osx";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(os), os, null);
            }
            if (Classifiers.ContainsKey(dictEntry)) {
                Classifiers[dictEntry].IsNative = true;
                result.Add(Classifiers[dictEntry]);
            } else if (Classifiers.ContainsKey(dictEntry + (IntPtr.Size == 8 ? "-64" : "-32"))) {
                Classifiers[dictEntry + (IntPtr.Size == 8 ? "-64" : "-32")].IsNative = true;
                result.Add(Classifiers[dictEntry + (IntPtr.Size == 8 ? "-64" : "-32")]);
            }
            return result;
        }
    }
}
