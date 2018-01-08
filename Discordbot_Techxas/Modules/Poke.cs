using Discord.Commands;
using System.Threading.Tasks;

namespace Discordbot_Techxas.Modules
{
    [Command("Poke")]
    public async Task PingAsync()
    {
        await ReplyAsync($"{Context.User.Mention} || THis does nothing now. Going to set it to DM a message to user poked");
    }
}
