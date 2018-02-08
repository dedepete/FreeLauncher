using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Yggdrasil
{
    public class Authenticate : Request
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public UserInfo selectedProfile { get; set; }
        public JObject user { get; set; }

        public Authenticate(string email, string password)
        {
            Url = Urls.Authenticate;
            ToPost = new JObject {
                {
                    "agent", new JObject {
                        {"name", "Minecraft"},
                        {"version", 1}
                    }
                },
                {"username", email},
                {"password", password},
                {"requestUser", true}
            }.ToString();
        }
    }
}
