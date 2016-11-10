using Newtonsoft.Json.Linq;

namespace dotMCLauncher.YaDra4il
{
    public class Authenticate : Request
    {
        public string accessToken;
        public string clientToken;
        public UserInfo selectedProfile;
        public JObject user;
        public Authenticate(string email, string password)
        {
            Url = Urls.Authenticate;
            ToPost = new JObject
            {
                {
                    "agent", new JObject
                    {
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
