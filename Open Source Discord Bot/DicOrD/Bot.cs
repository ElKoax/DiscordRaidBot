using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using raidfactory.raidbot;

//using WebSocketSharp;

namespace raidfactory
{
    public class WSResponse
    {
        public int op { get; set; }
        public dynamic d { get; set; }
    }

    public class BotCommands
    {

        public static void Join(string token, string invite)
        {
            try
            {
                if (new JoinBot(token, Proxies.GetRandomProxy()).JoinServer(invite) == false)
                    Join(token, invite);
            }
            catch { Join(token, invite); }
        }

        public static void Raid(string token, string channel_id, string message, int amt)
        {
            try
            {
                RaidBot bot = new RaidBot(token, Proxies.GetRandomProxy());
                for (int i = 1; i <= amt; i++)
                {
                    bot.SendMessage(channel_id, message);
                    Thread.Sleep(500);
                }
            }
            catch { Raid(token, channel_id, message, amt); }
        }





    }
}
