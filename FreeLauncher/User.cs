using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FreeLauncher
{
    public class User
    {
        [JsonProperty("username")]
        public string Username;
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("uuid")]
        public string Uuid;
        [JsonProperty("sessionToken")]
        public string SessionToken;
        [JsonProperty("accessToken")]
        public string AccessToken;
        [JsonProperty("properties")]
        public JArray UserProperties;
    }
}
