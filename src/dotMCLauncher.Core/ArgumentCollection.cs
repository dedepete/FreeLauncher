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
        /// Parses string.
        /// </summary>
        /// <param name="argLine">Input string.</param>
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
        /// Adds argument into collection.
        /// </summary>
        /// <param name="key">Switch. (Key without argument)</param>
        public void Add(string key)
        {
            Add(key, null);
        }

        /// <summary>
        /// Adds argument into collection.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public new void Add(string key, string value)
        {
            base.Add(key, value);
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
