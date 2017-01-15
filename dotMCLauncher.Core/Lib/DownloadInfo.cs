using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class DownloadInfo
    {
        [JsonProperty("classifiers")] public Dictionary<string, DownloadEntry> Classifiers;
        [JsonProperty("artifact")] public DownloadEntry Artifact;

        [JsonIgnore] public Lib ParentLib;

        public DownloadEntry GetDownloadsEntry(OperatingSystem os)
        {
            if (os == OperatingSystem.OTHER || Classifiers == null) {
                return Artifact;
            }
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
            }
            return Classifiers.ContainsKey(dictEntry)
                ? Classifiers[dictEntry]
                : Classifiers.ContainsKey(dictEntry + (IntPtr.Size == 8 ? "-64" : "-32"))
                    ? Classifiers[dictEntry + (IntPtr.Size == 8 ? "-64" : "-32")]
                    : Artifact;
        }

        public string GetPath(OperatingSystem os = OperatingSystem.OTHER) => GetDownloadsEntry(os).Path;

        public string GetUrl(OperatingSystem os = OperatingSystem.OTHER) => GetDownloadsEntry(os).Url;
    }
}
