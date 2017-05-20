using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class VersionManifest: Version
    {
        /// <summary>
        /// Аргументы.
        /// </summary>
        [JsonProperty("minecraftArguments")]
        public string Arguments
        {
            get { return _arguments; }
            set {
                ArgumentCollection = new ArgumentCollection<string, string>();
                ArgumentCollection.Parse(value);
                _arguments = value;
            }
        }

        /// <summary>
        /// Используемый файл ресурсов.
        /// </summary>
        [JsonProperty("assets")]
        public string AssetsIndex { get; set; }

        /// <summary>
        /// Главный класс игры.
        /// </summary>
        [JsonProperty("mainClass")]
        public string MainClass { get; set; }

        /// <summary>
        /// Список библиотек.
        /// </summary>
        [JsonProperty("libraries")]
        public List<Lib> Libs { get; set; }

        /// <summary>
        /// Родительская версия.
        /// </summary>
        [JsonProperty("inheritsFrom")]
        public string InheritsFrom { get; set; }

        [JsonProperty("downloads")]
        public VersionDownloadInfo DownloadInfo { get; set; }

        /// <summary>
        /// Родительская версия.
        /// </summary>
        [JsonIgnore]
        public VersionManifest InheritableVersionManifest { get; set; }

        /// <summary>
        /// Базовая строка аргументов.
        /// </summary>
        [JsonIgnore] private string _arguments;

        /// <summary>
        /// Список аргументов.
        /// </summary>
        [JsonIgnore] public ArgumentCollection<string, string> ArgumentCollection;

        [JsonIgnore]
        public string GetClientDownloadUrl
            =>
            DownloadInfo?.Client.Url ??
            $@"https://s3.amazonaws.com/Minecraft.Download/versions/{VersionId}/{VersionId}.jar";

        /// <summary>
        /// Парсинг JSON файла версии.
        /// </summary>
        /// <param name="pathToDirectory">Путь до директории с файлами версии.</param>
        /// <param name="parseInheritableVersion">Парсинг зависимой версии.</param>
        public static VersionManifest ParseVersion(DirectoryInfo pathToDirectory, bool parseInheritableVersion = true)
        {
            IsValid(pathToDirectory, true);
            string version = pathToDirectory.Name;
            VersionManifest ver = (VersionManifest)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")), typeof (VersionManifest));
            if (ver.InheritsFrom == null || !parseInheritableVersion) {
                return ver;
            }
            ver.InheritableVersionManifest =
                ParseVersion(new DirectoryInfo(Path.Combine(pathToDirectory.Parent.FullName, ver.InheritsFrom)));
            ver.Libs.AddRange(ver.InheritableVersionManifest.Libs);
            return ver;
        }

        public static bool IsValid(DirectoryInfo pathToDirectory, bool throwsExceptions = false)
        {
            string version = pathToDirectory.Name;
            if (!File.Exists(Path.Combine(pathToDirectory.ToString(), version + ".json"))) {
                if (throwsExceptions) {
                    throw new VersionIsNotExists(
                        $"Directory '{version}' doesn't contain JSON file. Path: {pathToDirectory}") {
                        Version = version
                    };
                }
                return false;
            }
            VersionManifest ver = (VersionManifest)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")), typeof(VersionManifest));
            if (ver == null) {
                if (throwsExceptions) {
                    throw new VersionIsNotExists(
                        $"Directory '{version}' contains invalid JSON file. Path: {pathToDirectory}") {
                        Version = version
                    };
                }
                return false;
            }
            return true;
        }
    }

    public class VersionIsNotExists : Exception
    {
        public string Version;
        public VersionIsNotExists(string message) : base(message) {}
    }
}
