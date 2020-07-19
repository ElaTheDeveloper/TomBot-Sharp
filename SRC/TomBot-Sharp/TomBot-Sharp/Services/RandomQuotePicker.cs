using System;
using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;

namespace TomBot_Sharp.Services
{
    public class RandomQuotePicker
    {
        public async Task MessageReceived(SocketMessage message)
        {  
            
            Random rand = new Random();
            if (rand.Next(0, 100) > 99)
            {
                String quote = String.Empty;

                String[] quotes = File.ReadAllLines("quotes.txt");
                var r = new Random();
                int randomLine = r.Next(0, quotes.Length - 1);
                String line = quotes[randomLine];
                await message.Channel.SendMessageAsync(line);
            }
            else
            {
                return;
            }
        }
    }
}