using System;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Yggdrasil
{
    public class Refresh : Request
    {
        public string accessToken { get; set; }
        public string clientToken { get; set; }
        public JObject user { get; set; }
        public Refresh(string accessToken, string clientToken)
        {
            Url = Urls.Refresh;
            ToPost = new JObject
            {
                {"accessToken", accessToken},
                {"clientToken", clientToken},
                {"requestUser", true}
            }.ToString();
        }
    }
}