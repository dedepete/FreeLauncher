using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;

namespace dotMCLauncher.Core
{
    public class ArgumentsGroup
    {
        public ArgumentsGroupType Type { get; set; }

        public List<Argument> Arguments;

        public string ToString(Dictionary<string, string> values)
        {
            string toReturn = string.Empty;
            foreach (Argument argument in Arguments) {
                switch (argument.Type) {
                    case ArgumentType.SINGLE:
                        toReturn += (argument as SingleArgument).Value + " ";
                        break;
                    case ArgumentType.EXTENDED:
                        ExtendedArgument extendedArgument = argument as ExtendedArgument;
                        if (!extendedArgument.IsForWindows()) {
                            continue;
                        }
                        if (!extendedArgument.HasMultipleArguments) {
                            toReturn += extendedArgument.Value + " ";
                            continue;
                        }
                        toReturn = extendedArgument.Values.Aggregate(toReturn, (current, value) => current + value + " ");
                        break;
                }
            }
            Regex re = new Regex(@"\$\{(\w+)\}", RegexOptions.IgnoreCase);
            toReturn = re.Replace(toReturn,
                                match => values.ContainsKey(match.Groups[1].Value)
                                    ? (!values[match.Groups[1].Value].Contains(" ")
                                        ? values[match.Groups[1].Value]
                                        : $"\"{values[match.Groups[1].Value]}\"")
                                    : match.Value);
            return toReturn;
        }
    }
}