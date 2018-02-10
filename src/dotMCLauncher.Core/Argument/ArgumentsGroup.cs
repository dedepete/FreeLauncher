using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotMCLauncher.Core
{
    public class ArgumentsGroup
    {
        public ArgumentsGroupType Type { get; set; }

        public List<Argument> Arguments;

        public string ToString(Dictionary<string, string> values, Rule[] rules = null)
        {
            StringBuilder toReturn = new StringBuilder();
            foreach (Argument argument in Arguments) {
                switch (argument.Type) {
                    case ArgumentType.SINGLE:
                        toReturn.Append((argument as SingleArgument).Value + " ");
                        break;
                    case ArgumentType.EXTENDED:
                        ExtendedArgument extendedArgument = argument as ExtendedArgument;
                        if (!extendedArgument.IsValid(rules)) {
                            continue;
                        }
                        if (!extendedArgument.HasMultipleArguments) {
                            toReturn.Append((extendedArgument.Value.Contains(' ')
                                ? "\"" + extendedArgument.Value + "\""
                                : extendedArgument.Value) + " ");
                            continue;
                        }
                        toReturn = extendedArgument.Values.Aggregate(toReturn,
                            (current, value) =>
                                toReturn.Append((Type == ArgumentsGroupType.JVM && value.Contains(' ')
                                    ? "\"" + value + "\""
                                    : value) + " "));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            Regex re = new Regex(@"\$\{(\w+)\}", RegexOptions.IgnoreCase);
            toReturn.Length--;
            return re.Replace(toReturn.ToString(),
                match => values.ContainsKey(match.Groups[1].Value)
                    ? (!values[match.Groups[1].Value].Contains(" ")
                        ? values[match.Groups[1].Value]
                        : $"\"{values[match.Groups[1].Value]}\"")
                    : match.Value);
        }
    }
}
