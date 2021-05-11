using System;
using System.Collections;
using System.Collections.Generic;
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
        
        
        [Command("randomcn")]
        [Summary("Returns the latest Citation Needed episode.")]
        public async Task LatestCNAsync()
        {
            FeedItem item = ParseFeed("https://www.youtube.com/feeds/videos.xml?playlist_id=PL96C35uN7xGIo2odDuuPeYtb7BtQ1kBhp");
            //int maxLength = 1000;
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
        [Command("random2otp")]
        [Summary("Returns the latest Two Of These People Are Lying episode.")]
        [Alias("latestlying", "latesttwo", "latesttotpl", "totpl")]
        public async Task LatestTotplAsync()
        {
            FeedItem item = ParseFeed("https://www.youtube.com/feeds/videos.xml?playlist_id=PLfx61sxf1Yz2I-c7eMRk9wBUUDCJkU7H0");
            // int maxLength = 1000;
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
        [Command("randomwtyp")]
        [Summary("Returns the latest Two Of These People Are Lying episode.")]
        [Alias("wtyp")]
        public async Task LatestWTYPAsync()
        {
            FeedItem item = ParseFeed("https://www.youtube.com/feeds/videos.xml?channel_id=UCPxHg4192hLDpTI2w7F9rPg");
            // int maxLength = 1000;
            var embed = new EmbedBuilder()
                {
                    Title = item.Title,
                    Description = @"podcast about engineering going not good. by donoteat02, AliceAvizandum, oldmanders0n& friends.",
                    ThumbnailUrl = "https://pbs.twimg.com/profile_images/1198008016299270147/2HtMrXDy_400x400.jpg",
                    Color = new Color(0,76,161),
                    Url = item.Link
                }
                .WithCurrentTimestamp()
                .Build();
            await ReplyAsync(embed: embed);
        }
        private FeedItem ParseFeed(String url)
        {
            Random rnd = new Random();
            var feed = FeedReader.ReadAsync(url);
            FeedItem[] itemList = feed.Result.Items.ToArray();
            return itemList[rnd.Next(0, itemList.Length)];
        }
    }
}