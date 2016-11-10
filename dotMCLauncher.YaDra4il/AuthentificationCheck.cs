namespace dotMCLauncher.YaDra4il
{
    public class AuthentificationCheck : Request
    {
        public bool valid;
        public AuthentificationCheck(string session)
        {
            Url = Urls.Validate;
            ToPost = "{\"accessToken\":\"" + session + "\"}";
        }
        public override Request DoPost()
        {
            try
            {
                base.DoPost();
                valid = true;
            }
            catch
            {
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
