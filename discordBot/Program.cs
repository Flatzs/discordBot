using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;



namespace discordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DiscordClient();
            var parse = new parseText();

            client.Connect("discordbot001@gmail.com", "gageandjason");
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            //GetServer(160590628621778945);


            //Echo back any message received, provided it didn't come from the bot itself
            client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                {
                    // Only parse messagine incoming with '!' prefix
                    if (e.Message.Text[0] == '!')
                    {

                        // Echo recieved message to console
                        Console.WriteLine(e.Message.User.ToString() + ": " + e.Message.Text);
                        // console.WriteLine(e.Message.Text);



                        // Parse message
                        string[] returnMsg = parse.ParseMessage(e.Message.Text);

                        // If return message -> respond to channel or user
                        if (returnMsg != null) {

                            // If return message to channel
                            if (returnMsg[0] == "c")
                            {
                                await e.Channel.SendMessage(returnMsg[1]);
                            }
                            else if (returnMsg[0] == "w")
                            {
                                await e.Message.User.SendMessage(returnMsg[1]);
                            }
                        }

                        
                    }
                }
            };

            if (client.Servers.Any())
            {
                Console.WriteLine(client.Servers);
            }
            else
            {
                Console.WriteLine("ERROR: Not connnected to server");
            }
            
            

            

            //wait for enter key
            Console.ReadLine();
          



        }
    }
}
