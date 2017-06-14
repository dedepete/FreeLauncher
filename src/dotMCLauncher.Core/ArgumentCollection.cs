using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotMCLauncher.Core
{
    public class ArgumentCollection : Dictionary<string, string>
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
                if (!ContainsKey(match[i].Groups[1].Value)) {
                    base.Add(match[i].Groups[1].Value, match[i].Groups[2].Value);
                } else {
                    base[match[i].Groups[1].Value] = match[i].Groups[2].Value;
                }
            }
            _argLine = re.Replace(argLine, string.Empty).Trim();
        }

        /// <summary>
        /// Добавление аргумента(ов) в список.
        /// </summary>
        /// <param name="key">Параметр.</param>
        public void Add(string key)
        {
            Add(key, null);
        }

        /// <summary>
        /// Добавление аргумента(ов) в список.
        /// </summary>
        /// <param name="key">Параметр.</param>
        /// <param name="value">Значение.</param>
        public new void Add(string key, string value)
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
            StringBuilder toReturn = new StringBuilder();
            if (!string.IsNullOrEmpty(_argLine)) {
                toReturn.Append(re.Replace(_argLine,
                                    match => values.ContainsKey(match.Groups[1].Value)
                                        ? (!values[match.Groups[1].Value].Contains(' ')
                                            ? values[match.Groups[1].Value]
                                            : $"\"{values[match.Groups[1].Value]}\"")
                                        : match.Value) + " ");
            }
            foreach (string key in Keys) {
                string value = string.Empty;
                if (base[key] != null && values != null && re.IsMatch(base[key])) {
                    value = re.Replace(base[key],
                        match =>
                            values.ContainsKey(match.Groups[1].Value)
                                ? values[match.Groups[1].Value]
                                : base[key]);
                } else if (base[key] != null) {
                    value = base[key];
                }
                if (value.Contains(' ')) {
                    value = $"\"{value}\"";
                }
                if (value != string.Empty) {
                    value = " " + value;
                }
                toReturn.Append($"--{key}{value} ");
            }
            return toReturn.ToString().Substring(0, toReturn.Length - 1);
        }
    }
}
