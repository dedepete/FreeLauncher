using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public abstract class Serializable
    {
        public string ToJson()
        {
            return ToJson(Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string ToJson(Formatting formatting)
        {
            return ToJson(formatting, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public string ToJson(Formatting formatting, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}