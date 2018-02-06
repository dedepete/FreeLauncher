using Newtonsoft.Json.Linq;

namespace dotMCLauncher.Core
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