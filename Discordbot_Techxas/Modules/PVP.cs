using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Discordbot_Techxas.Modules
{
    public class PVP : ModuleBase<SocketCommandContext>
    {
        static string SwitchCaseString = "nofight";

        static string player1;
        static string player2;

        static string whosTurn;
        static string whoWaits;
        static string placeHolder;

        static int health1 = 100;
        static int health2 = 100;

        [Command("fight")]
        [Alias("Fight")]
        [Summary("starts a fight with the @Mention user . Commands available are !Slash or !GiveUp (example: !fight Link5012")]
        public async Task Fight(IUser user)
        {

            if (Context.User.Mention != user.Mention && SwitchCaseString == "nofight")
            {
                SwitchCaseString = "fight_p1";
                player1 = Context.User.Mention;
                player2 = user.Mention;

                string[] whoStarts = new string[]
                {
                    Context.User.Mention,
                    user.Mention

                };

                Random rand = new Random();

                int randomIndex = rand.Next(whoStarts.Length);
                string text = whoStarts[randomIndex];

                whosTurn = text;
                if (text == Context.User.Mention)
                {
                    whoWaits = user.Mention;
                }
                else
                {
                    whoWaits = Context.User.Mention;
                }

                await ReplyAsync("Fight started between " + Context.User.Mention + " and " + user.Mention + "!\n\n" + player1 + " you got " + health1 + " health!\n" + player2 + " you got " + health2 + " health!\n\n" + text + " your turn!");

            }
            else
            {
                await ReplyAsync(Context.User.Mention + " sorry but there is a fight going on right now, or you just tried to fight urself...");
            }

        }


        [Command("giveup")]
        [Alias("GiveUp", "Giveup", "giveUp")]
        [Summary("Stops the fight and gives up.")]
        public async Task GiveUp()
        {
            if (SwitchCaseString == "fight_p1")
            {
                await ReplyAsync("The fight stopped.");
                SwitchCaseString = "nofight";
                health1 = 100;
                health2 = 100;
            }
            else
            {
                await ReplyAsync("There is no fight to stop.");
            }
        }

        [Command("Slash")]
        [Alias("slash")]
        [Summary("Slashes your foe with a sword. Good accuracy and medium damage")]
        public async Task Slash()
        {
            if (SwitchCaseString == "fight_p1")
            {
                if (whosTurn == Context.User.Mention)
                {
                    Random rand = new Random();

                    int randomIndex = rand.Next(1, 6);
                    if (randomIndex != 1)
                    {
                        Random rand2 = new Random();

                        int randomIndex2 = rand2.Next(7, 15);

                        if (Context.User.Mention != player1)
                        {
                            health1 = health1 - randomIndex2;
                            if (health1 > 0)
                            {
                                placeHolder = whosTurn;
                                whosTurn = whoWaits;
                                whoWaits = placeHolder;

                                await ReplyAsync(Context.User.Mention + " u hit and did " + randomIndex2 + " damage!\n\n" + player1 + " got " + health1 + " health left!\n" + player2 + " got " + health2 + " health left!\n\n" + whosTurn + " ur turn!");

                            }
                            else
                            {
                                await ReplyAsync(Context.User.Mention + " u hit and did " + randomIndex2 + " damage!\n\n" + player1 + " died. " + player2 + " won!");
                                SwitchCaseString = "nofight";
                                health1 = 100;
                                health2 = 100;
                            }
                        }
                        else if (Context.User.Mention == player1)
                        {
                            health2 = health2 - randomIndex2;
                            if (health2 > 0)
                            {
                                placeHolder = whosTurn;
                                whosTurn = whoWaits;
                                whoWaits = placeHolder;

                                await ReplyAsync(Context.User.Mention + " u hit and did " + randomIndex2 + " damage!\n\n" + player1 + " got " + health1 + " health left!\n" + player2 + " got " + health2 + " health left!\n\n" + whosTurn + " ur turn!");
                            }
                            else
                            {
                                await ReplyAsync(Context.User.Mention + " u hit and did " + randomIndex2 + " damage!\n\n" + player2 + " died. " + player1 + " won!");
                                SwitchCaseString = "nofight";
                                health1 = 100;
                                health2 = 100;
                            }
                        }
                        else
                        {
                            await ReplyAsync("Sorry it seems like something went wrong. Pls type !giveup");
                        }


                    }
                    else
                    {
                        placeHolder = whosTurn;
                        whosTurn = whoWaits;
                        whoWaits = placeHolder;

                        await ReplyAsync(Context.User.Mention + " sorry you missed!\n" + whosTurn + " ur turn!");
                    }
                }
                else
                {
                    await ReplyAsync(Context.User.Mention + " it is not your turn.");
                }
            }
            else
            {
                await ReplyAsync("There is no fight at the moment. Sorry :/");
            }

        }
    }
}