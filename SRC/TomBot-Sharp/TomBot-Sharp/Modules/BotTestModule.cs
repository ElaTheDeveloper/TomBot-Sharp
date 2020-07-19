using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace TomBot_Sharp.Modules
{
    public class BotTestModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Just here if you want to check TomBot is still alive.")]
        [Alias("keepalive", "areyouthere")]
        public async Task SendPingAsync()
        {
           
            await ReplyAsync("Pong! I'm here!");
        }

        [Command("contribute")]
        [Summary("Find out how you can contribute to TomBot.")]
        public async Task SendContribInfoAsync()
        {
            var embed = new EmbedBuilder()
                {
                    Title = "Contribute to TomBot",
                    Description = "Here is the information on how to contribute to TomBot!",
                    ThumbnailUrl = Context.Client.CurrentUser.GetAvatarUrl(),
                    Color = new Color(0,76,161)
                }
                .AddField("Quotes",
                    "Use the addquote command to add quotes from Citation Needed, Two Of These People Are Lying and The Audio Episodes.")
                .AddField("Code",
                    "If you like to write C#, head over to the [GitHub](https://github.com/ElaTheDeveloper/TomBot-Sharp) to help out!")
                .AddField("Hosting", "TomBot is hosted on a VPS, and therefore costs to host. If you want to cover a month's hosting (about $5 or £4), contact ElaTheDeveloper [here](https://elascorner.com/contact/)")
                .WithFooter("Thanks for helping out!")
                .WithCurrentTimestamp()
                .Build();
            await ReplyAsync(embed: embed);
        }

        [Command("version")]
        [Summary("Get TomBot version information")]
        public async Task SendVerInfoAsync()
        {
            await ReplyAsync($"TomBot-Sharp version {Assembly.GetExecutingAssembly().GetName().Version}. Running on {Environment.OSVersion.ToString()} (Processor Count (cores+threads): {Environment.ProcessorCount.ToString()})");
        }

        [Command("Uptime")]
        [Summary("Get the current uptime of TomBot")]
        [Alias("ut", "up")]
        public async Task SendUptimeAsync()
        {
            TimeSpan uptime = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            await ReplyAsync($"TomBot Uptime is currently {uptime.Days} days {uptime.Hours} hours {uptime.Minutes} minutes and {uptime.Seconds} seconds.");

        }
    }
}