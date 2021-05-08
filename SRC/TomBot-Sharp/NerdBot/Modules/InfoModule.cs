﻿using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;


namespace NerdBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo")]
        [Summary
            ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
            SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }

        [Command("about")]
        [Summary("A little bit about NerdBot")]
        public async Task AboutTBAsync()
        {
            await ReplyAsync(
                "NerdBot. Written By ElaTheDeveloper - Contribute on GitHub! - We flew a kite in a public place!");
        }
    }
}