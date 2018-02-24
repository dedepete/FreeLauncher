using Newtonsoft.Json;

namespace dotMCLauncher.Networking
{
    public class UserInfo : Request
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public UserInfo(string username)
        {
            Url = "https://api.mojang.com/profiles/minecraft";
            ToPost = "[\"" + username + "\"]";
        }

        public override Request Parse(string json)
        {
            return base.Parse(json.Trim('[', ']'));
        }
    }
}
