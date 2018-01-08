using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Discordbot_Techxas.Modules
{
    public class Hello : ModuleBase<SocketCommandContext>
    {
        [Command("Hello")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("HELLO!")
                .WithDescription($"{Context.User.Mention} Says HELLO to All.") //Removed @here from message
                .WithColor(Color.Green);

            await ReplyAsync("", false, builder.Build());
        }
    }
}