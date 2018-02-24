using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Versioning
{
    public class SingleArgument : Argument
    {
        public SingleArgument()
        {
            Type = ArgumentType.SINGLE;
        }

        public JToken Value { get; set; }
    }
}
