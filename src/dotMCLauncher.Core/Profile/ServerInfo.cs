﻿using Newtonsoft.Json;

namespace dotMCLauncher.Core
{
    public class ServerInfo
    {
        [JsonProperty("ip")] public string ServerIp { get; set; }
        [JsonProperty("port")] public uint ServerPort { get; set; } = 25565;

        public string BuildIp()
        {
            return ServerIp + ":" + ServerPort;
        }

        public string BuildArguments()
        {
            return $"--server {ServerIp} --port {ServerPort}";
        }
    }
}