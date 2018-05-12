namespace dotMCLauncher.Networking
{
    internal static class Urls
    {
        private const string _authServer = @"https://authserver.mojang.com";

        public const string Authenticate = _authServer + @"/authenticate";
        public const string Refresh = _authServer + @"/refresh";
        public const string Validate = _authServer + @"/validate";
        public const string Signout = _authServer + @"/signout";
        public const string Invalidate = _authServer + @"/invalidate";
    }
}
