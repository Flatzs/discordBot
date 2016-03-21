using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using RedditSharp;

namespace discordBot
{
    public class parseText
    {
        string[] jokeTitle = new string[40];
        string[] jokeBody = new string[40];
        string[] rule34Title = new string[40];
        string[] rule34Body = new string[40];

        public void Start()
        {
            Console.WriteLine("discordBot by Gage Langdon and Jason Odgers");
            Console.WriteLine("Loading...");
            getRedditJokes();
            getRedditRule34();
           
        }

        public string[] ParseCommand(string msg, MessageEventArgs e)
        {

            Random rand = new Random();
            int n; // used for random numbers

            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            // remove the leading '!'
            string[] parsedMsg = new string[1];
            parsedMsg[0] = msg.TrimStart('!');  // remove the excalamation mark 
            parsedMsg = parsedMsg[0].Split(' ');         // split apart in relation to spaces 

            // echoes trimmed command to console for debug
            //Console.WriteLine(parsedMsg[0]);

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
                case "cuckme":
                    //str_return[0] = "i"; // return msg as image
                    //str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\images\\cuck.gif";
                    e.Channel.SendMessage(e.Message.User.Mention + " got cucked");
                    e.Channel.SendFile("C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\images\\cuck.jpg");
                    break;
                case "roll":
                    if (parsedMsg.Length > 1)
                    {
                        
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

                        int randNum = rand.Next(100);

                        str_return[0] = "m"; // mention calling user
                        str_return[1] = " rolled " + randNum.ToString() + " out of 100";
                    }
                    break;
                case "members":
                    int totalMemCount = e.Server.Users.Count();
                    int onlineMemCount = e.Server.Users.Count(x => x.Status == UserStatus.Online);
                    str_return[1] = e.Server.Name + "\n\n" +
                                    "Total members: " + totalMemCount + "\n" +
                                    "Online members: " + onlineMemCount;
                    break;
                case "joke":
                    // return a random joke from the list
                    n = rand.Next(jokeTitle.Length - 1);
                    e.Channel.SendMessage(jokeTitle[n] + "\n\n" + jokeBody[n]);
                    break;
                case "rule34":
                    n = rand.Next(rule34Title.Length - 1);
                    e.Channel.SendMessage(rule34Title[n] + "\n\n" + rule34Body[n]);
                    break;
                case "test":
                    e.Channel.SendMessage("http://img1.123freevectors.com/wp-content/uploads/freevectorimage/happy-family-sitting-on-the-couch-free-vector-2189.jpg");
                    e.Message.Delete();
                    break;
                default:
                    return null;
                    //break;

            }

            if (str_return[1] == " ")
            {
                return null;
            }
            return str_return;
        }

        public string ParseCommand(string msg, Discord.User[] user)
        {

            return " ";
        }

        public string[] ParseMessage(string msg,MessageEventArgs e)
        {
            //Returns string array ["c"hannel" or "w"hisper , string message]
            string[] str_return = new string[2] { "c", " " };

            string[] parsedMsg = msg.Split(' ');


            for (int i = 0; i < parsedMsg.Length; i++)
            {
                // echoes message contents to console for debug purposes
                //Console.WriteLine(parsedMsg[i]);
                switch (parsedMsg[i])
                {
                    case "tts":
                        e.Channel.SendTTSMessage("this should be spoken using text to speech");
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


        private void getRedditJokes()
        {
            Console.WriteLine("Caching /r/jokes");
            Reddit reddit = new Reddit();

            var subreddit = reddit.GetSubreddit("/r/jokes");

            // get 20 of the current hot jokes
            int i = 0;
            foreach (var post in subreddit.Hot.Take(40))
            {
                jokeTitle[i] = post.Title.ToString();
                if (post.SelfText.Any())
                {
                    jokeBody[i] = post.SelfText.ToString();
                }
                i++;
            }
        }

        private void getRedditRule34()
        {
            Console.WriteLine("Caching /r/rule34");
            Reddit reddit = new Reddit();

            var subreddit = reddit.GetSubreddit("/r/rule34");

            // get 20 of the current hot images
            int i = 0;
            foreach (var post in subreddit.Hot.Take(40))
            {
                rule34Title[i] = post.Title.ToString();
                if (post.Url.AbsoluteUri.Any())
                {
                    rule34Body[i] = post.Url.AbsoluteUri.ToString();
                }
                i++;
            }

        }






    }
}
