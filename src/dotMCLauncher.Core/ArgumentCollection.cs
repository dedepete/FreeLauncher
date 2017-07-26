using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotMCLauncher.Core
{
    public class ArgumentCollection : Dictionary<string, List<string>>
    {
        private string _argLine;

        /// <summary>
        /// Parses string.
        /// </summary>
        /// <param name="argLine">Input string.</param>
        public void Parse(string argLine)
        {
            Regex re = new Regex(@"\-\-(\w+) (\S+)", RegexOptions.IgnoreCase);
            MatchCollection match = re.Matches(argLine);
            for (int i = 0; i < match.Count; i++) {
                if (!ContainsKey(match[i].Groups[1].Value)) {
                    Add(match[i].Groups[1].Value, new List<string>() { match[i].Groups[2].Value });
                } else {
                    base[match[i].Groups[1].Value].Add(match[i].Groups[2].Value);
                }
            }
            _argLine = re.Replace(argLine, string.Empty).Trim();
        }

        /// <summary>
        /// Adds argument into collection.
        /// </summary>
        /// <param name="key">Switch. (Key without argument)</param>
        public void Add(string key)
        {
            Add(key, new List<string>());
        }

        /// <summary>
        /// Adds argument into collection.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key, string value)
        {
            if (ContainsKey(key)) {
                base[key].Add(value);
                return;
            }
            Add(key, new List<string> { value });
        }

        /// <summary>
        /// Adds argument into collection.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="values">Values.</param>
        public void Add(string key, params string[] values)
        {
            if (!ContainsKey(key)) {
                Add(key, new List<string>());
            }
            foreach (string str in values) {
                base[key].Add(str);
            }
        }

        /// <summary>
        /// Builds argument line with replaced values.
        /// </summary>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        /// Builds argument line with replaced values.
        /// </summary>
        /// <param name="values">List of replaceable values.</param>
        public string ToString(Dictionary<string, string> values)
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
                if (base[key]?.Count > 0 && values != null) {
                    foreach (string str in base[key]) {
                        value = str;
                        if (re.IsMatch(str)) {
                            value = re.Replace(str,
                                match =>
                                    values.ContainsKey(match.Groups[1].Value)
                                        ? values[match.Groups[1].Value]
                                        : str);
                        }
                        if (value.Contains(' ')) {
                            value = $"\"{value}\"";
                        }
                        if (value != string.Empty) {
                            value = " " + value;
                        }
                        toReturn.Append($"--{key}{value} ");
                    }
                } else if (base[key]?.Count > 0) {
                    foreach (string str in base[key]) {
                        value = str;
                        if (value.Contains(' ')) {
                            value = $"\"{value}\"";
                        }
                        if (value != string.Empty) {
                            value = " " + value;
                        }
                        toReturn.Append($"--{key}{value} ");
                    }
                } else {
                    toReturn.Append($"--{key} ");
                }
            }
            return toReturn.ToString().Substring(0, toReturn.Length - 1);
        }
    }
}
