using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace raidfactory.raidbot
{
    public class HeaderOptions
    {
        public static string xSuperProperties = "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzc2LjAuMzc4OC4wIFNhZmFyaS81MzcuMzYiLCJicm93c2VyX3ZlcnNpb24iOiI3Ni4wLjM3ODguMCIsIm9zX3ZlcnNpb24iOiIxMCIsInJlZmVycmVyIjoiIiwicmVmZXJyaW5nX2RvbWFpbiI6IiIsInJlZmVycmVyX2N1cnJlbnQiOiIiLCJyZWZlcnJpbmdfZG9tYWluX2N1cnJlbnQiOiIiLCJyZWxlYXNlX2NoYW5uZWwiOiJzdGFibGUiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjozNjk0NSwiY2xpZW50X2V2ZW50X3NvdXJjZSI6bnVsbH0=";
        public static string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3788.0 Safari/537.36";
    }

    public class Message
    {
        public string content { get; set; }
        public string nonce { get; set; }
        public bool tts { get; set; }
    }

    public class RaidBot
    {
        private static HttpClient client = null;
        public RaidBot(string token, string proxy)
        {
            client = new HttpClient(new HttpClientHandler() { Proxy = new WebProxy(proxy) });
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("x-super-properties", HeaderOptions.xSuperProperties);
            client.DefaultRequestHeaders.Add("user-agent", HeaderOptions.userAgent);
        }

        public void SendMessage(string channel_id, string message) =>
            client.PostAsync($"https://discordapp.com/api/v6/channels/{channel_id}/messages", new StringContent(JsonConvert.SerializeObject(new Message { content = message, nonce = "", tts = false }), Encoding.UTF8, "application/json"));
    }
}
