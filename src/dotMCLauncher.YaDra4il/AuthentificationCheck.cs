namespace dotMCLauncher.YaDra4il
{
    public class AuthentificationCheck : Request
    {
        public bool valid { get; set; }
        public AuthentificationCheck(string accessToken)
        {
            Url = Urls.Validate;
            ToPost = "{\"accessToken\":\"" + accessToken + "\"}";
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
