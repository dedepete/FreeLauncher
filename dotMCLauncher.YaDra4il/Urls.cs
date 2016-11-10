namespace dotMCLauncher.YaDra4il
{
    internal static class Urls
    {
        private const string Authserver = @"https://authserver.mojang.com";

        public const string Authenticate = Authserver + @"/authenticate";
        public const string Refresh = Authserver + @"/refresh";
        public const string Validate = Authserver + @"/validate";
        public const string Signout = Authserver + @"/signout";
        public const string Invalidate = Authserver + @"/invalidate";
    }
}
