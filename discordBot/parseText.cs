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

        public string[] ParseMessage(string msg)
        {
            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            // remove the leading '!'
            string parsedMsg = msg.TrimStart('!');

            
            switch (parsedMsg)
            {
                case "help":
                    str_return[0] = "w"; // return msg as whisper 
                    str_return[1] = "this is help menu";
                    break;
                default:
                    return null;
                    //break;

            }

            
            return str_return;
        }

        public string ParseMessage(string msg, Discord.User[] user)
        {

            return " ";
        }




    }
}
