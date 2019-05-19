using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;


namespace raidfactory
{
    public class Tokens
    {
        public static string[] tokens = null;

        public static void ReadTokensFile()
        {
            //  Status("Reading 'tokens.txt' ...");
            Console.WriteLine("Yeet Reading dA gOoD ShIt");
            tokens = File.ReadAllLines("files/tokens.txt");
          //  Success("Successfully read all the tokens!");
        }
        public static void AutoTokens()
        {
            //Status("grabbing a couple tokens");
            //File.WriteAllText("files/tokens.txt", new HttpClient().GetStringAsync("SNIP LEL").Result);
            //Success("Got em nigger");
        }
        public static void LogTokenAmount() => Console.WriteLine($"There are {tokens.Length} tokens available for use!");
    }
}
