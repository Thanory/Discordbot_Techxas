using Discord.Commands;
using System.Threading.Tasks;

namespace Discordbot_Techxas.Modules
{
    public class Twitch : ModuleBase<SocketCommandContext>
    {
        //Clean this up later to be Context.Guild.Owner.WHATEVER THIER TWITTER/TWITCH/... PROFILE LINK(s) SHOWS
        [Command("Twitch")]
        public async Task PingAsync()
        {
            await ReplyAsync($"{Context.User.Mention} || {Context.Guild.Owner.Mention} streams live on Twitch at https://www.twitch.tv/thanory");
        }
    }
}
//Context.User;
//Context.Client;
//Context.Guild;
//Context.Message