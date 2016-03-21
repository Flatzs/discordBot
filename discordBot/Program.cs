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

            // Do the starting stuff for the commands
            parse.Start();

            // connect to discord
            client.Connect("discordbot001@gmail.com", "gageandjason");

            // recieve any system messages coming from discord
            client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            

            //Echo back any message received, provided it didn't come from the bot itself
            client.MessageReceived += async (s, e) =>
            {

                try {
                    if (!e.Message.IsAuthor)
                    {
                        // Only parse messagine incoming with '!' prefix
                        if (e.Message.Text.Any() && e.Message.Text[0] == '!')
                        {

                            // Echo recieved message to console
                            Console.WriteLine(e.Message.User.ToString() + ": " + e.Message.Text);


                            // Parse message (returned as string || NULL if no command)
                            string[] returnMsg = parse.ParseCommand(e.Message.Text, e);

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
                                // Mention back user that called command
                                else if (returnMsg[0] == "m")
                                {
                                    await e.Channel.SendMessage(e.Message.User.Mention + returnMsg[1]);
                                }
                            }
                        }
                        else // not parsing a command, but maybe a keyword
                        {
                            string[] returnMsg = parse.ParseMessage(e.Message.Text, e);

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
                }catch (Exception)
                {
                    Console.WriteLine("An exception has occured on the main thread, something unexpected happened");
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
