using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Networking
{
    public class Validate : Request
    {
        public bool Valid { get; set; }

        public Validate(string accessToken, string clientToken)
        {
            Url = Urls.Validate;
            ToPost = new JObject {
                {
                    "accessToken", accessToken
                }, {
                    "clientToken", clientToken
                }
            }.ToString();
        }

        public override Request DoPost()
        {
            try {
                base.DoPost();
                Valid = true;
            } catch {
                Valid = false;
            }
            return this;
        }

        public override Request Parse(string json)
        {
            return null;
        }
    }
}
