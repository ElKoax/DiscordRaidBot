using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace raidfactory
{
    public class JoinBot
    {
        private static HttpClient client = null;
        public JoinBot(string token, string proxy)
        {
            client = new HttpClient(new HttpClientHandler() { Proxy = new WebProxy(proxy) });
            client.DefaultRequestHeaders.Add("Authorization", token);
        }

        public bool JoinServer(string invite)
        {
            if (client.PostAsync($"https://discordapp.com/api/v6/invite/{invite}", null).Result.StatusCode != (HttpStatusCode)200) return false;
            return true;
        }
    }
}
