using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class VersionManifest: Version
    {
        /// <summary>
        /// Arguments.
        /// </summary>
        [JsonProperty("minecraftArguments")]
        public string Arguments
        {
            get { return _arguments; }
            set {
                ArgumentCollection = new ArgumentCollection();
                ArgumentCollection.Parse(value);
                _arguments = value;
            }
        }

        /// <summary>
        /// Assets ID.
        /// </summary>
        [JsonProperty("assets")]
        public string AssetsIndex { get; set; }

        /// <summary>
        /// Главный класс игры.
        /// </summary>
        [JsonProperty("mainClass")]
        public string MainClass { get; set; }

        /// <summary>
        /// Library list.
        /// </summary>
        [JsonProperty("libraries")]
        public List<Lib> Libs { get; set; }

        /// <summary>
        /// Parent's ID.
        /// </summary>
        [JsonProperty("inheritsFrom")]
        public string InheritsFrom { get; set; }

        [JsonProperty("downloads")]
        public VersionDownloadInfo DownloadInfo { get; set; }

        /// <summary>
        /// Parent's manifest.
        /// </summary>
        [JsonIgnore]
        public VersionManifest InheritableVersionManifest { get; set; }

        /// <summary>
        /// Argument line.
        /// </summary>
        [JsonIgnore] private string _arguments;

        /// <summary>
        /// Argument list.
        /// </summary>
        [JsonIgnore] public ArgumentCollection ArgumentCollection;

        [JsonIgnore]
        public string GetClientDownloadUrl
            =>
            DownloadInfo?.Client.Url ??
            $@"https://s3.amazonaws.com/Minecraft.Download/versions/{VersionId}/{VersionId}.jar";

        /// <summary>
        /// Parses build's JSON file.
        /// </summary>
        /// <param name="pathToDirectory">Path to build's directory.</param>
        public static VersionManifest ParseVersion(DirectoryInfo pathToDirectory) => ParseVersion(pathToDirectory, true);

        /// <summary>
        /// Parses build's JSON file.
        /// </summary>
        /// <param name="pathToDirectory">Path to build's directory.</param>
        /// <param name="parseInheritableVersion">Parses inheritable builds.</param>
        public static VersionManifest ParseVersion(DirectoryInfo pathToDirectory, bool parseInheritableVersion)
        {
            IsValid(pathToDirectory, true);
            string version = pathToDirectory.Name;
            VersionManifest ver =
                (VersionManifest)
                JsonConvert.DeserializeObject(
                    File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")),
                    typeof(VersionManifest));
            if (ver.InheritsFrom == null || !parseInheritableVersion) {
                return ver;
            }
            ver.InheritableVersionManifest =
                ParseVersion(new DirectoryInfo(Path.Combine(pathToDirectory.Parent.FullName, ver.InheritsFrom)));
            ver.Libs.AddRange(ver.InheritableVersionManifest.Libs);
            return ver;
        }

        public static bool IsValid(DirectoryInfo pathToDirectory) => IsValid(pathToDirectory, false);

        public static bool IsValid(DirectoryInfo pathToDirectory, bool throwsExceptions)
        {
            string version = pathToDirectory.Name;
            if (!File.Exists(Path.Combine(pathToDirectory.ToString(), version + ".json"))) {
                if (throwsExceptions) {
                    throw new VersionCorruptedOrNotExists(
                        $"Directory '{version}' doesn't contain JSON file. Path: {pathToDirectory}") {
                        Version = version
                    };
                }
                return false;
            }
            VersionManifest ver = (VersionManifest)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")), typeof(VersionManifest));
            if (ver != null) {
                return true;
            }
            if (throwsExceptions) {
                throw new VersionCorruptedOrNotExists(
                    $"Directory '{version}' contains corrupted JSON file. Path: {pathToDirectory}") {
                    Version = version
                };
            }
            return false;
        }
    }

    public class VersionCorruptedOrNotExists : Exception
    {
        public string Version;
        public VersionCorruptedOrNotExists(string message) : base(message) {}
    }
}
