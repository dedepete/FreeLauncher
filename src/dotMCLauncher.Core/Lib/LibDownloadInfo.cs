using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class LibDownloadInfo
    {
        [JsonProperty("classifiers")] public Dictionary<string, DownloadEntry> Classifiers;
        [JsonProperty("artifact")] public DownloadEntry Artifact;

        [JsonIgnore] public Lib ParentLib;

        public List<DownloadEntry> GetDownloadsEntries(OperatingSystem os)
        {
            List<DownloadEntry> result = new List<DownloadEntry>();
            if (os == OperatingSystem.OTHER || Classifiers == null) {
                result.Add(Artifact);
                return result;
            }
            result.Add(Artifact);
            string dictEntry = string.Empty;
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
