namespace dotMCLauncher.YaDra4il
{
    public class UserInfo : Request
    {
        public string id { get; set; }
        public string name { get; set; }

        public UserInfo(string username)
        {
            Url = "https://api.mojang.com/profiles/minecraft";
            ToPost = "[\"" + username + "\"]";
        }

        public override Request Parse(string json)
        {
            return base.Parse(json.Trim('[', ']'));
        }
    }
}
