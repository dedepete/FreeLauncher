using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Yggdrasil
{
    public class Authenticate : Request
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("clientToken")]
        public string ClientToken { get; set; }

        [JsonProperty("selectedProfile")]
        public UserInfo SelectedProfile { get; set; }

        [JsonProperty("user")]
        public JObject User { get; set; }

        public Authenticate(string email, string password)
        {
            Url = Urls.Authenticate;
            ToPost = new JObject {
                {
                    "agent", new JObject {
                        {
                            "name", "Minecraft"
                        }, {
                            "version", 1
                        }
                    }
                }, {
                    "username", email
                }, {
                    "password", password
                }, {
                    "requestUser", true
                }
            }.ToString();
        }
    }
}
