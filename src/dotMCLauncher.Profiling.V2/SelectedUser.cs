using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class SelectedUser : Serializable
    {
        [JsonProperty("account")]
        public string SelectedGuid { get; set; }

        [JsonProperty("profile")]
        public string SelectedProfile { get; set; }
    }
}