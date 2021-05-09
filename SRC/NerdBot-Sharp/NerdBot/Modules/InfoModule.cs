using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace NerdBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        public InfoModule(CommandService commandService)
        {
            CommandService = commandService;
        }

        public CommandService CommandService { get; set; }
        
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
        public async Task AboutBotAsync()
        {
            await ReplyAsync(
                "NerdBot. Written By ElaTheDeveloper - Contribute on GitHub! - We flew a kite in a public place!");
        }
        
        
        [Command("help")]
        [Summary("What commands does NerdBot understand? Let's find out!")]
        public async Task HelpCommand()
        {

            List<CommandInfo> commands = CommandService.Commands.ToList();
            EmbedBuilder embedBuilder = new EmbedBuilder();
            embedBuilder.WithAuthor(Context.Client.CurrentUser)
                .WithColor(Color.Gold)
                .WithDescription("These are all the commands I understand! Run one by adding ! before it.\n[Support NerdBot](https://github.com/ElaTheDeveloper/NerdBot-Sharp)")
                .WithTitle("NerdBot Help")
                .WithFooter($"{commands.Count} commands in database")
                .WithCurrentTimestamp();

            foreach (CommandInfo command in commands)
            {
                // Get the command Summary attribute information
                string embedFieldText = command.Summary ?? "No description available\n";

                embedBuilder.AddField(command.Name, embedFieldText);
            }

            await ReplyAsync("Here's a list of commands and their description: ", false, embedBuilder.Build());
        }
    }
}