using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Net.Http;
using System.IO;
//using static raidfactory.ConsoleFunctions;

namespace raidfactory
{
    public class Proxies
    {
        private static Random random = new Random();
        public static string[] proxies = null;

        public static void ReadProxiesFile()
        {
            // Status("Reading 'proxies.txt' ...");
            proxies = File.ReadAllLines("files/proxies.txt");
            //  Success("Successfully read all the proxies!");
        }
        public static void ScrapeProxies()
        {
            //   Status("Scraping proxies...");
            File.WriteAllText("files/proxies.txt", new HttpClient().GetStringAsync("https://api.proxyscrape.com/?request=displayproxies&proxytype=http&timeout=250").Result);
            //  Success("Successfully scraped fresh proxies!");
            ReadProxiesFile();
        }
        public static void LogProxyAmount() => Console.WriteLine($"There are {proxies.Length} proxies available!");
        public static string GetRandomProxy() { return proxies[random.Next(proxies.Length)]; }
    }
}
