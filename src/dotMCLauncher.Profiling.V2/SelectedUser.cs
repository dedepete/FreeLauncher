using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class SelectedUser
    {
        [JsonProperty("account")]
        public string SelectedGUID { get; set; } = "2.0.1003";

        [JsonProperty("profile")]
        public string SelectedProfile { get; set; } = "2.0.1003";
    }
}