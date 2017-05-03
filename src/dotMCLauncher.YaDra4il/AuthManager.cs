using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.YaDra4il
{
    public class AuthManager
    {
        [JsonProperty("email")]
        public string Email;
        [JsonProperty("password")]
        public string Password;

        [JsonProperty("username")]
        public string Username;
        [JsonProperty("uuid")]
        public string Uuid;
        [JsonProperty("sessionToken")]
        public string SessionToken;
        [JsonProperty("accessToken")]
        public string AccessToken;

        [JsonProperty("demo")]
        public bool IsDemo;
        [JsonProperty("legacy")]
        public bool IsLegacy;

        public JArray UserProperties;

        public Authenticate Login()
        {
            var auth = Login(Email, Password);
            SessionToken = auth.accessToken;
            AccessToken = auth.clientToken;
            Username = auth.selectedProfile.name;
            Uuid = auth.selectedProfile.id;
            UserProperties = (JArray)auth.user["properties"];
            return auth;
        }

        private Authenticate Login(string email, string password)
        {
            var auth = new Authenticate(email, password);
            auth = (Authenticate)auth.DoPost();
            return auth;
        }

        public void Logout()
        {
            Logout(Email, Password);
        }

        private static void Logout(string email, string password)
        {
            var signout = new Signout(email, password);
            signout.DoPost();
        }

        public Refresh Refresh()
        {
            var refresh = new Refresh(SessionToken, AccessToken);
            refresh = (Refresh)refresh.DoPost();
            SessionToken = refresh.accessToken;
            AccessToken = refresh.clientToken;
            UserProperties = (JArray)refresh.user["properties"];
            return refresh;
        }

        public bool CheckSessionToken()
        {
            var valid = CheckSessionToken(SessionToken);
            return valid;
        }

        private static bool CheckSessionToken(string sessionToken)
        {
            var check = new AuthentificationCheck(sessionToken);
            return ((AuthentificationCheck)check.DoPost()).valid;
        }

        public string GetUsernameByUuid()
        {
            Username = new Username
            {
                Uuid = Uuid
            }.GetUsernameByUuid();
            return Username;
        }

        public UserInfo GetUserInfo()
        {
            var inform = GetUserInfo(Username);
            Uuid = inform.id;
            return inform;
        }
        public static UserInfo GetUserInfo(string username)
        {
            var inform = new UserInfo(username);
            inform = (UserInfo)inform.DoPost();
            return inform;
        }
    }
}
