﻿using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Discordbot_Techxas.Modules
{
    public class Twitter : ModuleBase<SocketCommandContext>
    {
        //Clean this up later to be Context.Guild.Owner.WHATEVER THIER TWITTER/TWITCH/... PROFILE LINK(s) SHOWS
        [Command("Twitter")]
        public async Task PingAsync()
        {
            await ReplyAsync($"{Context.User.Mention} || You can find {Context.Guild.Owner.Mention} 's brain dumps of knowledge and randomness at NEED TO MAKE LINK READ FROM DISCORD PROFILE");
        }        
    }
}
//Context.User;
//Context.Client;
//Context.Guild;
//Context.Message