using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;
using RedditSharp;
using Tweetinvi;

namespace discordBot
{
    public class parseText
    {

        //string wotd = "Norscout is THE GOAT"; // Word of the day

        string[] dongers = new string[] { "⊂(▀¯▀⊂)","ᕙ(˵ ಠ ਊ ಠ ˵)ᕗ","( ͡↑ ͜ʖ ͡↑)","┌༼◉ل͟◉༽┐",
                                          "ᕕ( ՞ ᗜ ՞ )ᕗ","(ノ͡° ͜ʖ ͡°)ノ︵┻┻","╚═། ◑ ▃ ◑ །═╝","(V●ᴥ●V)",
                                          "┌༼ – _ – ༽┐","⋋| ◉ ͟ʖ ◉ |⋌", "¯\\_| ಠ ∧ ಠ |_/¯", "┌[ ◔ ͜ ʖ ◔ ]┐"
                                         };

        string[] lookAtMeImg = new string[] {"E:\\Documents\\GitHub\\discordBot\\images\\look.gif",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look1.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look2.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look3.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look4.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look5.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look6.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look7.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look8.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look9.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look10.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look11.jpg",
                                             "E:\\Documents\\GitHub\\discordBot\\images\\look12.jpg"};

        string[] danceImg = new string[] { "E:\\Documents\\GitHub\\discordBot\\images\\dance.gif",
                                           "E:\\Documents\\GitHub\\discordBot\\images\\dance1.gif",
                                           "E:\\Documents\\GitHub\\discordBot\\images\\dance3.gif",
                                           "E:\\Documents\\GitHub\\discordBot\\images\\dance4.gif",
                                           "E:\\Documents\\GitHub\\discordBot\\images\\dance5.gif",
                                           "E:\\Documents\\GitHub\\discordBot\\images\\dance6.gif",};


        string[] jokeTitle = new string[40];
        string[] jokeBody = new string[40];
        string[] rule34Title = new string[40];
        string[] rule34Body = new string[40];
        string[] rule34LOLTitle = new string[40];
        string[] rule34LOLBody = new string[40];

       
        string[] pornTweets = new string[40];


        public void Start()
        {
            // Initial loading 
            Console.WriteLine("discordBot by Gage Langdon and Jason Odgers");
            Console.WriteLine("Loading...");
            getPornTweets();
            getRedditJokes();
            getRedditRule34();
            getRedditRule34LOL();

           
        }

        //variables for the quiz game
        private string[] questionsandanswers = { "" };
        private bool quizisrunning = false;
        private int randomindexnumber = 0;
        private DateTime quizstartime;

        public string[] ParseCommand(string msg, MessageEventArgs e)
        {
            string[] str_return = new string[2] { "c", " " };

            try {
                Random rand = new Random();
               
                int n; // used for random numbers

               
                




                // remove the leading '!'
                string[] parsedMsg = new string[1];
                parsedMsg[0] = msg.TrimStart('!');  // remove the excalamation mark 
                parsedMsg = parsedMsg[0].Split(' ');         // split apart in relation to spaces 

                // Console.WriteLine(parsedMsg[0]);

                parsedMsg[0] = parsedMsg[0].ToLower();

                // echoes trimmed command to console for debug
                //Console.WriteLine(parsedMsg[0]);

                switch (parsedMsg[0])
                {
                    case "help":
                        str_return[0] = "w"; // return msg as whisper 
                        str_return[1] = ("HI! I'M MR MEESEEKS! LOOK AT ME!\n" +
                                        "We are created to serve a singular purpose, for which we will go to any lengths to fulfill!\n" +
                                        "\n\n" +

                                        "When you type certain commands I might do something, Check out the commands you can use below\n\n" +
                                        "!help  - Recieve this help message\n" +
                                        "!promo - tell members about me!\n" +
                                        "!jgi - ON YO FOHEAD\n" +
                                        "!roll [max] - default is out of 100\n" +
                                        "!bunny - meow\n" +
                                        "!yay - celebrate!\n" +
                                        "!joke - recieve a random joke from /r/jokes\n" +
                                        "!rule34 - recieve a random rule34 from /r/rule34 [only in NSFW channels]\n" +
                                        "!rule34lol - random league of legends rule34 from /r/rule34lol [only in NSFW channels]\n" +
                                        "!cuckme - hope you like em big\n" +
                                        "!hug [@user] - cheer em up!\n" +
                                        "!quiz - recieve a random trivia question\n" +
                                        "!members - number of users on server\n" +
                                        "!g [search] - LET ME GOOGLE THAT FOR YOU\n" +
                                        "!dongers - RAISE EM\n" +
                                        "!lookatme - LOOK AT ME!!!!11\n" +
                                        "!dance - gnn tss gnn tss\n" +
                                        "!porncomment - random porn comment\n" +
                                        "!fite [@user] - fite me irl br0\n" +
                                        "!tldr - TOO LONG DIDNT READ\n" +

                                        "\n\n" +
                                        "Mr.Meeseeks is being developed by @Grits, pm feedback"
                                        );

                        break;
                    case "bunny":
                        str_return[0] = "i"; // return msg as image
                        str_return[1] = "E:\\Documents\\GitHub\\discordBot\\images\\bunny.jpeg";
                        break;
                    case "yay":
                        str_return[0] = "i"; // return msg as image
                        str_return[1] = "E:\\Documents\\GitHub\\discordBot\\images\\yay.gif";
                        break;
                    case "cuckme":
                        //str_return[0] = "i"; // return msg as image
                        //str_return[1] = "C:\\Users\\Gage\\Documents\\GitHub\\discordBot\\images\\cuck.gif";
                        e.Channel.SendMessage(e.Message.User.Mention + " got cucked");
                        e.Channel.SendFile("E:\\Documents\\GitHub\\discordBot\\images\\cuck.jpg");
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
                            str_return[1] = " rolled " + randNum.ToString() + " out of " + maxVal.ToString();



                        }
                        else
                        {

                            int randNum = rand.Next(100);

                            str_return[0] = "m"; // mention calling user
                            str_return[1] = " rolled " + randNum.ToString() + " out of 100";
                        }
                        break;
                    case "quiz":
                        if (!quizisrunning || (e.Message.Timestamp >= quizstartime.AddSeconds(25)))
                        {
                            //Note the time of the start of the quiz
                            quizstartime = e.Message.Timestamp;
                            quizisrunning = true;

                            //Import the list of jokes from file and add them to a list
                            List<string[]> questionsandanswereslist = new List<string[]>();
                            string[] temparray = System.IO.File.ReadAllLines("E:\\Documents\\GitHub\\discordBot\\discordBot\\quizquestions\\questions.txt");
                            foreach (string lines in temparray)
                            {
                                questionsandanswereslist.Add(lines.Split('`'));
                            }

                            //Select a new index from the list of jokes through random number generation.
                            Random randomindexgenerator = new Random();
                            randomindexnumber = randomindexgenerator.Next(questionsandanswereslist.Count());
                            questionsandanswers = questionsandanswereslist.ElementAt(randomindexnumber);
                            e.Channel.SendMessage("You have 25 seconds to get the right answer. To answer, type !answer followed by the answer. \n\n " + questionsandanswers[0]); //+ " " +  questionsandanswers[1]);

                        }

                        else
                        {
                            return null;
                        }

                        break;
                    case "answer":
                        if (quizisrunning) {
                            string answer = " ";
                            string messagetext = e.Message.Text;

                            try {
                                answer = messagetext.Remove(0, 8).ToLower();
                            } catch (Exception) {
                                Console.WriteLine("ERROR: Answer has no argument");
                            }

                            // if no exception
                            if (answer != " ")
                            {
                                if (answer == questionsandanswers[1].ToLower() && e.Message.Timestamp <= quizstartime.AddSeconds(25))
                                {
                                    e.Channel.SendMessage("Congrats " + e.Message.User.Mention + ", You are correct!");
                                    randomindexnumber = 0;
                                    quizisrunning = false;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                        // send answer to channel if time ended with not correct answer
                        //else if (e.Message.Timestamp >= quizstartime.AddSeconds(25))
                        //{
                        //    e.Channel.SendMessage("The correct answer was " + questionsandanswers[1]);
                        //}


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
                        if (e.Message.Channel.Id == 152880849367465995) {
                            n = rand.Next(rule34Title.Length - 1);
                            e.Channel.SendMessage(rule34Title[n] + "\n\n" + rule34Body[n]);
                        }
                        else
                        {
                            e.Channel.SendMessage("NSFW commands are not allowed here " + e.Message.User.Mention);
                            //Console.WriteLine(e.Message.User + " attempted to call a NSFW command in channel: " + e.Message.Channel.Name);
                            // Console.WriteLine(e.Message.Channel.Id);
                        }

                        break;
                    case "rule34lol":
                        if (e.Message.Channel.Id == 152880849367465995)
                        {
                            n = rand.Next(rule34Title.Length - 1);
                            e.Channel.SendMessage(rule34LOLTitle[n] + "\n\n" + rule34LOLBody[n]);
                        }
                        else
                        {

                            e.Channel.SendMessage("NSFW commands are not allowed here " + e.Message.User.Mention);
                            // Console.WriteLine(e.Message.User + " attempted to call a NSFW command in channel: " + e.Message.Channel.Name);
                            // Console.WriteLine(e.Message.Channel.Id);
                        }

                        break;
                    case "jgi":
                        e.Channel.SendFile("E:\\Documents\\GitHub\\discordBot\\images\\jgi.png");
                        break;
                    case "dongers":
                        n = rand.Next(dongers.Length - 1);
                        e.Channel.SendMessage(dongers[n]);
                        break;
                    case "g":
                        e.Channel.SendMessage("Here you go " + "https://www.google.com/search?q=" + parsedMsg[1] + "+");
                        //e.Message.Delete();
                        break;
                    case "promo":
                        e.Channel.SendFile("E:\\Documents\\GitHub\\discordBot\\images\\promo.jpg");
                        break;
                    case "porncomment":
                        n = rand.Next(pornTweets.Length - 1);
                        e.Channel.SendMessage(pornTweets[n]);
                        break;
                    case "lookatme":
                        n = rand.Next(lookAtMeImg.Length - 1);
                        e.Channel.SendFile(lookAtMeImg[n]);
                        break;
                    case "dance":
                        n = rand.Next(danceImg.Length - 1);
                        e.Channel.SendFile(danceImg[n]);
                        break;
                    case "tldr":
                        e.Channel.SendFile("E:\\Documents\\GitHub\\discordBot\\images\\tldr.gif");
                        break;
                    case "hug":
                        e.Channel.SendMessage(e.Message.User.Mention + " hugged " + e.Message.MentionedUsers.First().Mention);
                        break;
                    case "fite":
                        n = rand.Next(2);
                        if (n == 0)
                        {
                            e.Channel.SendMessage(e.Message.User.Mention + " won the fite against " + e.Message.MentionedUsers.First().Mention);
                        }
                        else
                        {
                            e.Channel.SendMessage(e.Message.MentionedUsers.First().Mention + " won the fite against " + e.Message.User.Mention);
                        }
                        break;
                    default:
                        return null;
                        //break;

                }

                
            } catch (Exception)
            {
                Console.WriteLine("ERROR: An exception occured in parseText.cs");
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
                    case "fag":
                        try{
                            Discord.User u = e.Server.FindUsers("brad 👀", true) as Discord.User;
                            if (u.Name == "brad")
                            {
                                e.Channel.SendTTSMessage(u.Mention + " is a faggot");
                            }
                            else
                            {
                                e.Channel.SendTTSMessage("brad is a faggot");
                            }
                        }catch (Exception)
                        {
                            e.Channel.SendTTSMessage("brad is a faggot");
                        }
                        return null;
                    case "jgi":
                        str_return[0] = "c";
                        str_return[1] = "JGI on y0 fo head!!!11";
                        return str_return;
                    default:
                        str_return[0] = null;
                        break;

                }
            }

            if (str_return[1] == " ")
            {
                return null;
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

        private void getRedditRule34LOL()
        {
            Console.WriteLine("Caching /r/Rule34LoL");
            Reddit reddit = new Reddit();

            var subreddit = reddit.GetSubreddit("/r/Rule34LoL");

            // get 20 of the current hot images
            int i = 0;
            foreach (var post in subreddit.Hot.Take(40))
            {
                rule34LOLTitle[i] = post.Title.ToString();
                if (post.Url.AbsoluteUri.Any())
                {
                    rule34LOLBody[i] = post.Url.AbsoluteUri.ToString();
                }
                i++;
            }

        }

        private void getPornTweets()
        {
            Console.WriteLine("Caching porn comment tweets");

            try {
                // authenticate and connect to the twitter api
                Auth.SetUserCredentials("5bzCIcNofQXZ8kpCkwYLNo9Pp",
                    "DQ0YZLInDBUnWyCcte9KBs5G1wQriNSzAzCVsI3lG0LT9GXUW2",
                    "712137448994648065-D2tmKQq0Njn2dR8vB1tnHCB7Kk0KKPi",
                    "ct0WJYVEEAeXWYlzG52oAtvxz85QuCJindnI1VDUqCy6c");

                // get the top 40 tweets
                var tweets = Timeline.GetUserTimeline("wisewordsofporn", 40);

                for (int i = 0; i < tweets.Count(); i++)
                {
                    pornTweets[i] = tweets.ElementAt(i).Text;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: exception thrown in getPornTweets()");
            }
            
        }






    }
}
