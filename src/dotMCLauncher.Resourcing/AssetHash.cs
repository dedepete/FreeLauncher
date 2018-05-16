namespace dotMCLauncher.Resourcing
{
    public class AssetHash
    {
        private string _value { get; set; }

        public string GetFullPath()
        {
            return _value == null ? null : _value.Substring(0, 2) + @"\" + _value;
        }

        public string GetDirectoryName()
        {
            return _value?.Substring(0, 2);
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator AssetHash(string @string)
        {
            return new AssetHash() {
                _value = @string
            };
        }

        public static implicit operator string(AssetHash assetHash)
        {
            return assetHash._value;
        }
    }
}
