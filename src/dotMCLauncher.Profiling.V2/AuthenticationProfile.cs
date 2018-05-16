using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class AuthenticationProfile : Serializable
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}