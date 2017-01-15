using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace dotMCLauncher.Core
{
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
                } else if (base[key] != null) {
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
}
