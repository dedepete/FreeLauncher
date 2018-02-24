using System.Net;
using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Networking
{
    public class Username
    {
        public string Uuid { private get; set; }

        public string GetUsernameByUuid()
        {
            string res =
                new WebClient().DownloadString("https://sessionserver.mojang.com/session/minecraft/profile/" + Uuid);
            JObject jo = JObject.Parse(res);
            return jo["name"].ToString();
        }
    }
}
