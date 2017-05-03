using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public abstract class Version
    {
        /// <summary>
        /// Идентификатор версии.
        /// </summary>
        [JsonProperty("id")]
        public string VersionId { get; set; }

        /// <summary>
        /// Тип релиза.
        /// </summary>
        [JsonProperty("type")]
        public string ReleaseType { get; set; }
    }
}