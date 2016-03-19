using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace discordBot
{
    public class parseText
    {

        public string[] ParseCommand(string msg)
        {
            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            // remove the leading '!'
            string parsedMsg = msg.TrimStart('!');

            
            switch (parsedMsg)
            {
                case "help":
                    str_return[0] = "w"; // return msg as whisper 
                    str_return[1] = ("Hey! I'm a bot being developed by @Grits and @tapetape\n"+
                                    "When you type certain commands I might do something, Check out the commands you can use below\n\n"+
                                    "!help  - Recieve this help message\n"+
                                    "!bunny - picture of a bunny :)\n"+
                                    "!yay - celebrate!"
                                    );
                    
                    break;
                case "bunny":
                    str_return[0] = "i"; // return msg as image
                    str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\discordBot\\images\\bunny.jpeg";
                    break;
                case "yay":
                    str_return[0] = "i"; // return msg as image
                    str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\discordBot\\images\\yay.gif";
                    break;
                default:
                    return null;
                    //break;

            }

            
            return str_return;
        }

        public string ParseCommand(string msg, Discord.User[] user)
        {

            return " ";
        }

        public string[] ParseMessage(string msg)
        {
            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            string[] parsedMsg = msg.Split(' ');


            for (int i = 0; i < parsedMsg.Length; i++)
            {
                Console.WriteLine(parsedMsg[i]);
                switch (parsedMsg[i])
                {
                    case "fag":
                        str_return[0] = "c";
                        str_return[1] = "fag";
                        return str_return;
                    case "jgi":
                        str_return[0] = "c";
                        str_return[1] = "JGI on y0 fo head!!!11";
                        return str_return;
                    default:
                        str_return[0] = null;
                        break;

                }
            }


            return str_return;
        }




    }
}
