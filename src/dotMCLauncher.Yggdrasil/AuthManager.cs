using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Yggdrasil
{
    public class AuthManager
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("sessionToken")]
        public string ClientToken { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("demo")]
        public bool IsDemo { get; set; }

        [JsonProperty("legacy")]
        public bool IsLegacy { get; set; }

        public JArray UserProperties { get; set; }

        public Authenticate Login()
        {
            Authenticate auth = Login(Email, Password);
            ClientToken = auth.clientToken;
            AccessToken = auth.accessToken;
            Username = auth.selectedProfile.name;
            Uuid = auth.selectedProfile.id;
            UserProperties = (JArray) auth.user["properties"];
            return auth;
        }

        private Authenticate Login(string email, string password)
        {
            Authenticate auth = new Authenticate(email, password);
            auth = (Authenticate) auth.DoPost();
            return auth;
        }

        public void Logout()
        {
            Logout(Email, Password);
        }

        private static void Logout(string email, string password)
        {
            Signout signout = new Signout(email, password);
            signout.DoPost();
        }

        public Refresh Refresh()
        {
            Refresh refresh = new Refresh(ClientToken, AccessToken);
            refresh = (Refresh) refresh.DoPost();
            ClientToken = refresh.accessToken;
            AccessToken = refresh.clientToken;
            UserProperties = (JArray) refresh.user["properties"];
            return refresh;
        }

        public bool CheckClientToken()
        {
            bool valid = CheckClientToken(AccessToken, ClientToken);
            return valid;
        }

        private static bool CheckClientToken(string accessToken, string clientToken)
        {
            AuthentificationCheck check = new AuthentificationCheck(accessToken, clientToken);
            return ((AuthentificationCheck) check.DoPost()).valid;
        }

        public string GetUsernameByUuid()
        {
            Username = new Username {
                Uuid = Uuid
            }.GetUsernameByUuid();
            return Username;
        }

        public UserInfo GetUserInfo()
        {
            UserInfo inform = GetUserInfo(Username);
            Uuid = inform.id;
            return inform;
        }

        public static UserInfo GetUserInfo(string username)
        {
            UserInfo inform = new UserInfo(username);
            inform = (UserInfo) inform.DoPost();
            return inform;
        }
    }
}
