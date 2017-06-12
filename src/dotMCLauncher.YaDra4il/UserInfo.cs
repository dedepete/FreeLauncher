namespace dotMCLauncher.YaDra4il
{
    public class UserInfo : Request
    {
        public string id;
        public string name;

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
