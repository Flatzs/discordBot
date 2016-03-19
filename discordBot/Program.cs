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

                        
                        // Parse message (returned as string || NULL if no command)
                        string[] returnMsg = parse.ParseCommand(e.Message.Text);

                        // If return message -> respond to channel or user
                        if (returnMsg != null)
                        {

                            // If return message to channel
                            if (returnMsg[0] == "c")
                            {
                                await e.Channel.SendMessage(returnMsg[1]);
                            }
                            // If return message as private whisper
                            else if (returnMsg[0] == "w")
                            {
                                await e.Message.User.SendMessage(returnMsg[1]);
                            }
                            // If sending image file to channel
                            else if (returnMsg[0] == "i")
                            {
                                await e.Channel.SendFile(returnMsg[1]);
                            }   
                        }  
                    }
                    else // not parsing a command, but maybe a keyword
                    {
                        string[] returnMsg = parse.ParseMessage(e.Message.Text);

                        if (returnMsg != null)
                        {
                            if (returnMsg[0] == "c")
                            {
                                if (returnMsg[1] == "fag")
                                {
                                    await e.Channel.SendTTSMessage("brad is a faggot");
                                }
                                else
                                    await e.Channel.SendTTSMessage(returnMsg[1]);
                            }
                        }

                        

                    }
                }
            };

            if (client.Servers.Any())
            {
                Console.WriteLine("Connected to Discord!");
                Console.WriteLine(client.Servers);
            }
            else
            {
                Console.WriteLine("Connecting to Discord...");
            }   





            //wait for enter key before closing program
            Console.ReadLine();
        }
    }
}
