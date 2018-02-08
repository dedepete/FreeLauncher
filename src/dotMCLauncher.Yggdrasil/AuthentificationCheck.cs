namespace dotMCLauncher.Yggdrasil
{
    public class AuthentificationCheck : Request
    {
        public bool valid { get; set; }

        public AuthentificationCheck(string accessToken, string clientToken)
        {
            Url = Urls.Validate;
            ToPost = "{\"accessToken\":\"" + accessToken + "\",\"clientToken\":\"" + clientToken + "\"}";
        }

        public override Request DoPost()
        {
            try {
                base.DoPost();
                valid = true;
            }
            catch {
                valid = false;
            }
            return this;
        }

        public override Request Parse(string json)
        {
            return null;
        }
    }
}
