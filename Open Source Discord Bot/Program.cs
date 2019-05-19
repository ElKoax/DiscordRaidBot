using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using raidfactory;
using System.IO;
using System.Threading;
using System.Net.Http;

namespace Open_Source_Discord_Bot
{

    class Program
    {


        //private static string[] tokens = null;

        static void Main(string[] args)
        {
            Console.Title = "Open Sourced Discord Spammer//Bomber";

            Console.WriteLine("Made by ElKoax and Xenith (Used some of his code cause ye)");
            Directory.CreateDirectory("./files/");
            Proxies.ScrapeProxies();
            Proxies.ReadProxiesFile();

            Tokens.ReadTokensFile();

            Thread.Sleep(20000);

            for (; ; )
            {
                Console.WriteLine("");

                Console.WriteLine("Type your command below.");
                string cmd = Console.ReadLine();
                string[] cmdparams = cmd.Split(' ');

                switch (cmdparams[0].ToLower())
                {
                    case "join":
                        File.WriteAllText("files/tokens.txt", new HttpClient().GetStringAsync("http://134.209.188.102/Yeet/token.txt").Result);
                        Console.WriteLine("Input the invite of the server you would like to join bot below:", ConsoleColor.Magenta);
                        Console.WriteLine(">", ConsoleColor.Blue); //SetColor(ConsoleColor.White);
                        string join_inv = Console.ReadLine();
                      //  string join_p_inv = InviteFunctions.ParseInvite(join_inv);
                     //   if (InviteFunctions.CheckInvite(join_p_inv) == false)
                      //  {
                       //     Error($"The invite you have provided ({join_inv}) is invalid! Please try again with a valid invite.");
                      //      return;
                    //    }

                        foreach (string token in Tokens.tokens)
                            new Thread(() => BotCommands.Join(token, join_inv)).Start();
                        Thread.Sleep(50);
                        break;
                    case "raid":
                        Console.WriteLine("im too lazy to write this lol,");


                        break;


                }
            }




        }
    }
}
