using Newtonsoft.Json;
using System.Collections.Generic;

namespace dotMCLauncher.Profiling.V2 {
    public class AuthenticationEntry : Serializable
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("profiles")]
        public Dictionary<string, AuthenticationProfile> Profiles { get; set; }
    }
}