using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace NerdBot.Modules
{
    public class BotTestModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Just here if you want to check NerdBot is still alive.")]
        [Alias("keepalive", "areyouthere")]
        public async Task SendPingAsync()
        {
           
            await ReplyAsync("Pong! I'm here!");
        }

        [Command("contribute")]
        [Summary("Find out how you can contribute to NerdBot.")]
        public async Task SendContribInfoAsync()
        {
            var embed = new EmbedBuilder()
                {
                    Title = "Contribute to NerdBot",
                    Description = "Here is the information on how to contribute to NerdBot!",
                    ThumbnailUrl = Context.Client.CurrentUser.GetAvatarUrl(),
                    Color = new Color(0,76,161)
                }
                .AddField("Quotes",
                    "Use the addquote command to add quotes.")
                .AddField("Code",
                    "If you like to write C#, let Ela know or visit the [GitHub](https://github.com/ElaTheDeveloper/NerdBot-Sharp).")
                .AddField("Hosting", "NerdBot is hosted on a VPS, and therefore costs to host. If you want to cover a month's hosting (about $5 or £4), you can support Ela on [Patreon here](https://patreon.com/elathedeveloper)")
                .WithFooter("Thanks for helping out!")
                .WithCurrentTimestamp()
                .Build();
            await ReplyAsync(embed: embed);
        }

        [Command("version")]
        [Summary("Get NerdBot version information")]
        public async Task SendVerInfoAsync()
        {
            await ReplyAsync($"NerdBot version {Assembly.GetExecutingAssembly().GetName().Version}. Running on {Environment.OSVersion.ToString()} (Processor Count (cores+threads): {Environment.ProcessorCount.ToString()})");
        }

        [Command("Uptime")]
        [Summary("Get the current uptime of NerdBot")]
        [Alias("ut", "up")]
        public async Task SendUptimeAsync()
        {
            TimeSpan uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            await ReplyAsync($"NerdBot Uptime is currently {uptime.Days} days {uptime.Hours} hours {uptime.Minutes} minutes and {uptime.Seconds} seconds.");

        }
    }
}