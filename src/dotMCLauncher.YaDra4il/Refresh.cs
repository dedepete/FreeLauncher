using System;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.YaDra4il
{
    public class Refresh : Request
    {
        public string accessToken;
        public string clientToken;
        public JObject user;
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

        public override Request Parse(string json)
        {
            Console.WriteLine(json);
            return base.Parse(json);
        }
    }
}