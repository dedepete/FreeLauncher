using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Core
{
    public class VersionManifest : Version
    {
        [JsonIgnore]
        public VersionManifestType Type { get; set; } = VersionManifestType.V1;

        /// <summary>
        /// Arguments. v1
        /// </summary>
        [JsonProperty("minecraftArguments")]
        public string Arguments
        {
            get {
                return _arguments;
            }
            set {
                _arguments = value;
                ArgCollection = new ArgumentCollection();
                ArgCollection.Parse(value);
            }
        }

        /// <summary>
        /// Arguments. v2
        /// </summary>
        [JsonProperty("arguments")]
        private JObject ArgumentGroups
        {
            get {
                return ArgGroups != null ? JObject.Parse(JsonConvert.SerializeObject(ArgGroups)) : null;
            }
            set {
                Type = VersionManifestType.V2;
                ArgGroups = new List<ArgumentsGroup>();
                foreach (KeyValuePair<string, JToken> pair in value) {
                    ArgumentsGroup group = new ArgumentsGroup();
                    group.Type = pair.Key.ToUpperInvariant() == "GAME"
                        ? ArgumentsGroupType.GAME
                        : ArgumentsGroupType.JVM;
                    group.Arguments = new List<Argument>();
                    JArray array = (JArray) pair.Value;
                    foreach (JToken token in array) {
                        if (token is JValue) {
                            group.Arguments.Add(new SingleArgument {
                                Value = token
                            });
                        } else {
                            ExtendedArgument arg = (ExtendedArgument)
                                JsonConvert.DeserializeObject(token.ToString(), typeof(ExtendedArgument));
                            group.Arguments.Add(arg);
                        }
                    }
                    ArgGroups.Add(group);
                }
            }
        }

        /// <summary>
        /// Assets ID.
        /// </summary>
        [JsonProperty("assets")]
        public string AssetsIndex { get; set; }

        /// <summary>
        /// Main class.
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
        /// Argument line. v1
        /// </summary>
        [JsonIgnore]
        private string _arguments { get; set; }

        /// <summary>
        /// Argument list. v1
        /// </summary>
        [JsonIgnore]
        public ArgumentCollection ArgCollection { get; set; }

        /// <summary>
        /// Groups of arguments. v2
        /// </summary>
        [JsonIgnore]
        public List<ArgumentsGroup> ArgGroups { get; set; }

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
            VersionManifest ver = (VersionManifest) JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")), typeof(VersionManifest));
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

        public string GetAssetsIndex()
        {
            if (!string.IsNullOrEmpty(AssetsIndex)) {
                return AssetsIndex;
            }
            VersionManifest manifest = InheritableVersionManifest;
            while (true) {
                if (manifest.InheritsFrom == null) {
                    if (manifest.AssetsIndex != null) {
                        return manifest.AssetsIndex;
                    }
                    break;
                }
                manifest = manifest.InheritableVersionManifest;
            }
            throw new VersionCorrupted("Can't get assets index.") {
                Version = VersionId
            };
        }

        public string GetBaseJar()
        {
            return InheritsFrom == null ? VersionId : InheritableVersionManifest.GetBaseJar();
        }
    }

    public class VersionCorruptedOrNotExists : Exception
    {
        public string Version { get; set; }
        public VersionCorruptedOrNotExists(string message) : base(message) { }
    }

    public class VersionCorrupted : Exception
    {
        public string Version { get; set; }
        public VersionCorrupted(string message) : base(message) { }
    }
}
