using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Versioning
{
    public class ExtendedArgument : Argument
    {
        public ExtendedArgument()
        {
            Type = ArgumentType.EXTENDED;
        }

        [JsonProperty("value")]
        public JToken Value
        {
            get {
                if (!HasMultipleArguments) {
                    return new JValue(Values?[0]);
                }
                JArray array = new JArray();
                foreach (string value in Values) {
                    array.Add(value);
                }
                return array;
            }
            set {
                Values = new List<string>();
                JArray array = value.Type == JTokenType.Array ? value as JArray : new JArray(value);
                if (array.Count > 1) {
                    HasMultipleArguments = true;
                    foreach (JToken jToken in array) {
                        Values.Add(jToken.ToString());
                    }
                    return;

                }
                Values.Add(array[0].ToString());
            }
        }

        [JsonProperty("rules")]
        private List<Rule> _rules { get; set; }

        public List<string> Values { get; set; }

        public bool HasMultipleArguments { get; set; }

        public bool IsForWindows()
        {
            if (_rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in _rules) {
                switch (rule.Action) {
                    case "allow":
                        toReturn = (rule.Os == null && rule.Features == null) || rule.Os?.Name == "windows";
                        break;
                    case "disallow":
                        toReturn = (rule.Os == null && rule.Features == null) ? toReturn : rule.Os?.Name != "windows";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rule.Action), rule.Action, null);
                }
            }
            return toReturn;
        }

        public bool IsValid(params Rule[] rules)
        {
            if (rules == null) {
                return true;
            }
            bool toReturn = false;
            foreach (Rule rule in _rules) {
                foreach (Rule reqRule in rules) {
                    if (reqRule.Action == rule.Action &&
                        reqRule.Features?.IsForCustomResolution == rule.Features?.IsForCustomResolution &&
                        reqRule.Features?.IsForDemoUser == rule.Features?.IsForDemoUser &&
                        reqRule.Os?.Name == rule.Os?.Name &&
                        reqRule.Os?.Version == rule.Os?.Version) {
                        toReturn = true;
                    }
                }

            }
            return toReturn;
        }
    }
}
