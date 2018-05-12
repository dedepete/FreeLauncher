using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Networking
{
    public class Refresh : Request
    {
        public string AccessToken { get; set; }
        public string ClientToken { get; set; }
        public JObject User { get; set; }

        public Refresh(string accessToken, string clientToken)
        {
            AccessToken = accessToken;
            ClientToken = clientToken;
            Url = Urls.Refresh;
            ToPost = new JObject {
                {
                    "accessToken", accessToken
                }, {
                    "clientToken", clientToken
                }, {
                    "requestUser", true
                }
            }.ToString();
        }

        public override Request Parse(string json)
        {
            JObject jobject = JObject.Parse(json);
            Refresh request = new Refresh(jobject["accessToken"].ToString(), jobject["clientToken"].ToString()) {
                User = (JObject) jobject["user"]
            };
            return request;
        }
    }
}
