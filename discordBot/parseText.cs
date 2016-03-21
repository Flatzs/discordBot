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

        public string[] ParseCommand(string msg, MessageEventArgs e)
        {
            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            // remove the leading '!'
            string[] parsedMsg = new string[1];
            parsedMsg[0] = msg.TrimStart('!');  // remove the excalamation mark 
            parsedMsg = parsedMsg[0].Split(' ');         // split apart in relation to spaces 

            Console.WriteLine(parsedMsg[0]);
            switch (parsedMsg[0])
            {
                case "help":
                    str_return[0] = "w"; // return msg as whisper 
                    str_return[1] = ("Hey! I'm a bot being developed by @Grits and @tapetape\n"+
                                    "When you type certain commands I might do something, Check out the commands you can use below\n\n"+
                                    "!help  - Recieve this help message\n"+
                                    "!roll [max] - default is out of 100\n"+
                                    "!bunny - picture of a bunny :)\n"+
                                    "!yay - celebrate!"
                                    );
                    
                    break;
                case "bunny":
                    str_return[0] = "i"; // return msg as image
                    str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\images\\bunny.jpeg";
                    break;
                case "yay":
                    str_return[0] = "i"; // return msg as image
                    str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\images\\yay.gif";
                    break;
                case "roll":
                    if (parsedMsg.Length > 1)
                    {
                        Random rand = new Random();
                        int maxVal;

                        // see if user entered a valid number for the max value
                        if (!Int32.TryParse(parsedMsg[1], out maxVal))
                        {
                            // if not a valid param, default is 100
                            maxVal = 100;
                        }
                        
                        int randNum = rand.Next(maxVal);

                        str_return[0] = "m"; // mention calling user
                        str_return[1] = " rolled " + randNum.ToString() + " out of " + maxVal.ToString() ;
 
                    }
                    else
                    {
                        Random rand = new Random();
                        int randNum = rand.Next(100);

                        str_return[0] = "m"; // mention calling user
                        str_return[1] = " rolled " + randNum.ToString() + " out of 100";
                    }
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
