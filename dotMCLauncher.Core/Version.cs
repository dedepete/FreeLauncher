using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class Version
    {
        /// <summary>
        /// Идентификатор версии.
        /// </summary>
        [JsonProperty("id")]
        public string VersionId { get; set; }

        /// <summary>
        /// Тип релиза.
        /// </summary>
        [JsonProperty("type")]
        public string ReleaseType { get; set; }

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

        /// <summary>
        /// Родительская версия.
        /// </summary>
        [JsonIgnore]
        public Version InheritableVersion { get; set; }

        /// <summary>
        /// Базовая строка аргументов.
        /// </summary>
        [JsonIgnore] private string _arguments;

        /// <summary>
        /// Список аргументов.
        /// </summary>
        [JsonIgnore] public ArgumentCollection<string, string> ArgumentCollection;

        /// <summary>
        /// Парсинг JSON файла версии.
        /// </summary>
        /// <param name="pathToDirectory">Путь до директории с файлами версии.</param>
        /// <param name="parseInheritableVersion">Парсинг зависимой версии.</param>
        public static Version ParseVersion(DirectoryInfo pathToDirectory, bool parseInheritableVersion = true)
        {
            string version = pathToDirectory.Name;
            if (!File.Exists(Path.Combine(pathToDirectory.ToString(), version + ".json"))) {
                throw new VersionIsNotExists($"Directory '{version}' doesn't contain JSON file. Path: {pathToDirectory}") {
                    Version = version
                };
            }
            Version ver = (Version)JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(pathToDirectory.ToString(), version + ".json")), typeof (Version));
            if (ver.InheritsFrom == null || !parseInheritableVersion) {
                return ver;
            }
            ver.InheritableVersion =
                ParseVersion(new DirectoryInfo(Path.Combine(pathToDirectory.Parent.FullName, ver.InheritsFrom)));
            ver.Libs.AddRange(ver.InheritableVersion.Libs);
            return ver;
        }
    }

    public class VersionIsNotExists : Exception
    {
        public string Version;
        public VersionIsNotExists(string message) : base(message) {}
    }
}
