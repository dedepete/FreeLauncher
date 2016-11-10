using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    public class Lib
    {
        /// <summary>
        /// Название библиотеки.
        /// </summary>
        [JsonProperty("name")] public string Name;

        /// <summary>
        /// Информация для загрузки файла.
        /// </summary>
        [JsonProperty("downloads")] public DownloadsData DownloadsData;

        [JsonProperty("natives")] private JObject _natives;
        [JsonProperty("rules")] private List<Rule> Rules;

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
            if (Rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in Rules) {
                switch (rule.action) {
                    case "allow":
                        toReturn = rule.os == null || rule.os["name"].ToString() == "windows";
                        break;
                    case "disallow":
                        toReturn = rule.os == null ? toReturn : rule.os["name"].ToString() != "windows";
                        break;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Возвращает путь к библиотеке.
        /// </summary>
        /// <param name="generate">При True генерирует значение из названия библиотеки.</param>
        /// <param name="os">Требуемая операционная система.</param>
        public string GetPath(bool generate = false,
            DownloadsData.OperatingSystems os = DownloadsData.OperatingSystems.OTHER)
        {
            string[] s = Name.Split(':');
            return (generate || DownloadsData == null)
                ? string.Format("{0}\\{1}\\{2}\\{1}-{2}" +
                                (!string.IsNullOrEmpty(IsNative) ? "-" + IsNative : string.Empty) + ".jar",
                    s[0].Replace('.', '\\'), s[1], s[2])
                : DownloadsData.GetDownloadsEntry(os).Path;
        }

        /// <summary>
        /// Возвращает путь к библиотеке.
        /// </summary>
        /// <param name="os">Требуемая операционная система.</param>
        public string GetPath(DownloadsData.OperatingSystems os)
        {
            return GetPath(false, os);
        }
    }

    public class Rule
    {
        public string action;
        public JObject os;
    }

    public class DownloadsData
    {
        [JsonProperty("classifiers")] public Dictionary<string, DownloadsEntry> Classifiers;
        [JsonProperty("artifact")] public DownloadsEntry Artifact;

        public enum OperatingSystems
        {
            WINDOWS,
            LINUX,
            MACOS,
            OTHER
        }

        public DownloadsEntry GetDownloadsEntry(OperatingSystems os)
        {
            if (os == OperatingSystems.OTHER || Classifiers == null) {
                return Artifact;
            }
            string dictEntry = string.Empty;
            switch (os) {
                case OperatingSystems.WINDOWS:
                    dictEntry = "natives-windows";
                    break;
                case OperatingSystems.LINUX:
                    dictEntry = "natives-linux";
                    break;
                case OperatingSystems.MACOS:
                    dictEntry = "natives-osx";
                    break;
            }
            return Classifiers.ContainsKey(dictEntry) ? Classifiers[dictEntry] : Artifact;
        }

        public string GetPath(OperatingSystems os = OperatingSystems.OTHER) => GetDownloadsEntry(os).Path;

        public string GetUrl(OperatingSystems os = OperatingSystems.OTHER) => GetDownloadsEntry(os).Url;
    }

    public class DownloadsEntry
    {
        [JsonProperty("path")] public string Path;
        [JsonProperty("url")] public string Url;
    }

    public class ArgumentCollection<T1, T2> : Dictionary<string, string>
    {
        private string _argLine;

        /// <summary>
        /// Парсинг строки.
        /// </summary>
        /// <param name="argLine">Исходная строка.</param>
        public void Parse(string argLine)
        {
            Regex re = new Regex(@"\-\-(\w+) (\S+)", RegexOptions.IgnoreCase);
            MatchCollection match = re.Matches(argLine);
            for (int i = 0; i < match.Count; i++) {
                if (!base.ContainsKey(match[i].Groups[1].Value)) {
                    base.Add(match[i].Groups[1].Value, match[i].Groups[2].Value);
                }
                else {
                    base[match[i].Groups[1].Value] = match[i].Groups[2].Value;
                }
            }
            _argLine = re.Replace(argLine, string.Empty).Trim();
        }

        /// <summary>
        /// Добавление аргумента(ов) в список.
        /// </summary>
        /// <param name="key">Параметр.</param>
        /// <param name="value">Значение. Может быть пустым.</param>
        public new void Add(string key, string value = null)
        {
            base.Add(key, value);
        }

        /// <summary>
        /// Построение строки аргументов по списку значений.
        /// </summary>
        /// <param name="values">Список заменяемых значений.</param>
        public string ToString(Dictionary<string, string> values = null)
        {
            Regex re = new Regex(@"\$\{(\w+)\}", RegexOptions.IgnoreCase);
            string temp = !string.IsNullOrEmpty(_argLine)
                ? re.Replace(_argLine,
                    match => values.ContainsKey(match.Groups[1].Value)
                        ? (!values[match.Groups[1].Value].Contains(' ')
                            ? values[match.Groups[1].Value]
                            : $"\"{values[match.Groups[1].Value]}\"")
                        : match.Value) + " "
                : string.Empty;
            foreach (string key in base.Keys) {
                string tempValue = string.Empty;
                if (base[key] != null && values != null && re.IsMatch(base[key])) {
                    tempValue = re.Replace(base[key],
                        match =>
                            values.ContainsKey(match.Groups[1].Value)
                                ? values[match.Groups[1].Value]
                                : base[key]);
                }
                else if (base[key] != null) {
                    tempValue = base[key];
                }
                if (tempValue.Contains(' ')) {
                    tempValue = $"\"{tempValue}\"";
                }
                if (tempValue != string.Empty) {
                    tempValue = " " + tempValue;
                }
                temp = temp + ("--" + key + tempValue + " ");
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }
    }

    public class VersionIsNotExists : Exception
    {
        public string Version;
        public VersionIsNotExists(string message) : base(message) {}
    }
}
