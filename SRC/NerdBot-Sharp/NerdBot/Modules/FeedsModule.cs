using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace NerdBot.Modules
{
    public class FeedsModule : ModuleBase<SocketCommandContext>
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        
        [Command("latestcn")]
        [Summary("Returns the latest Citation Needed episode.")]
        public async Task LatestCNAsync()
        {
            FeedItem item = ParseFeed("https://www.youtube.com/feeds/videos.xml?playlist_id=PL96C35uN7xGIo2odDuuPeYtb7BtQ1kBhp");
            int maxLength = 1000;
            var embed = new EmbedBuilder()
                {
                    Title = item.Title,
                    ThumbnailUrl = "https://usesthis.com/images/interviews/tom.scott/portrait.jpg",
                    Color = new Color(0,76,161),
                    Url = item.Link
                }
                .WithCurrentTimestamp()
                .Build();
            await ReplyAsync(embed: embed);
        }
        [Command("latestpeople")]
        [Summary("Returns the latest Two Of These People Are Lying episode.")]
        [Alias("latestlying", "latesttwo", "latesttotpl", "totpl")]
        public async Task LatestTotplAsync()
        {
            FeedItem item = ParseFeed("https://www.youtube.com/feeds/videos.xml?playlist_id=PLfx61sxf1Yz2I-c7eMRk9wBUUDCJkU7H0");
            int maxLength = 1000;
            var embed = new EmbedBuilder()
                {
                    Title = item.Title,
                    Description = @"This probably still doesn't work...",
                    ThumbnailUrl = "https://usesthis.com/images/interviews/tom.scott/portrait.jpg",
                    Color = new Color(0,76,161),
                    Url = item.Link
                }
                .WithCurrentTimestamp()
                .Build();
            await ReplyAsync(embed: embed);
        }

        private FeedItem ParseFeed(String url)
        {
            var feed = FeedReader.ReadAsync(url);
            FeedItem[] itemList = feed.Result.Items.ToArray();
            return itemList[0];
        }
    }
}