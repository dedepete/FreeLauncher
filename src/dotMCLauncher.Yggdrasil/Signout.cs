namespace dotMCLauncher.Yggdrasil
{
    public class Signout : Request
    {
        public Signout(string email, string password)
        {
            Url = Urls.Signout;
            ToPost = new Newtonsoft.Json.Linq.JObject
            {
                {"username", email},
                {"password", password},
            }.ToString();
        }

        public override Request Parse(string json)
        {
            return null;
        }
    }
}
