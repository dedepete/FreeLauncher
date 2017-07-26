using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Core
{
    public class Rule
    {
        public string action { get; set; }
        public JObject os { get; set; }
    }
}
