using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class ServerInfo
    {
        [JsonProperty("ip")] public string ServerIP;
        [JsonProperty("port")] public uint ServerPort = 25565;

        public string BuildIP()
        {
            return ServerIP + ":" + ServerPort;
        }

        public string BuildArguments()
        {
            return $"--server {ServerIP} --port {ServerPort}";
        }
    }
}