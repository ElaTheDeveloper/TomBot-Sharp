using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using System.IO;


namespace TomBot_Sharp.Modules
{
    public class QuoteModule : ModuleBase<SocketCommandContext>
    {
        [Command("addquote")]
        [Summary("Add a quote to the quote list.")]
        [Alias("aq")]
        public async Task AddQuoteAsync(params String[] quote)
        {
            //build the array into a string because parameters are always in arrays
            String final = String.Empty;
            foreach (var str in quote)
            {
                if (str != " ")
                    final += $" {str}";
            }

            if (final != String.Empty || final != null)
            {
                StreamWriter w = File.AppendText("quotes.txt");
                w.WriteLine(final);
                w.Close();
            }
            await ReplyAsync($"Added {final}");
        }

        [Command("quote")]
        [Summary(
            "Have TomBot tell you a random quote from Citation Needed, Tech Diff or Two Of These People Are Lying.")]
        [Alias("q")]
        public async Task GetQuoteAsync()
        {
            String quote = String.Empty;
            
            String[] quotes = File.ReadAllLines("quotes.txt");
            var r = new Random();
            int randomLine = r.Next(0, quotes.Length - 1);
            String line = quotes[randomLine];

            await ReplyAsync(line.ToString());
        }
    }
}