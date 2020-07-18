using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Net;
using NLog.Fluent;
using DotNetEnv;

namespace TomBot_Sharp
{
    class Program
    {
        
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private DiscordSocketClient _client;

        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            new Program().MainAsync().GetAwaiter().GetResult();
        }


        public async Task MainAsync()
        {
            Logger.Info("TomBot MainAsync() Started");
            _client = new DiscordSocketClient();

            _client.Log += Log;

            
            _client.MessageReceived += MessageReceived;
            
            // Remember to keep token private or to read it from an 
            // external source! In this case, we are reading the token 
            // from an environment variable. If you do not know how to set-up
            // environment variables, you may find more information on the 
            // Internet or by using other methods such as reading from 
            // a configuration.
            Logger.Info("Using Discord Token: " + Environment.GetEnvironmentVariable("DiscordToken"));
            Logger.Info("Logging into Discord now!");
            await _client.LoginAsync(TokenType.Bot, 
                Environment.GetEnvironmentVariable("DiscordToken"));
            
            
            await _client.StartAsync();

            
            
            
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private async Task MessageReceived(SocketMessage message)
        { 
            //This is horrific and needs replacing with something better
            Logger.Info(
                $"Message Recieved. Channel: {message.Channel.Name} Author: {message.Author.Username}, Content: {message.Content}");
            if (message.Content == "!ping")
            {
                Logger.Info("Hello World! command response.");
                await message.Channel.SendMessageAsync("Pong!");
            }
        }
        private Task Log(LogMessage msg)
        {
            switch (msg.Severity)
            {
                case LogSeverity.Critical:
                    Logger.Fatal($"Discord.NET|{msg.Source}|{msg.Message}"); 
                    break;
                case  LogSeverity.Error:
                    Logger.Error($"Discord.NET|{msg.Source}|{msg.Message}");
                    break;
                case LogSeverity.Warning: 
                    Logger.Warn($"Discord.NET|{msg.Source}|{msg.Message}"); 
                    break;
                case LogSeverity.Info: 
                    Logger.Info($"Discord.NET|{msg.Source}|{msg.Message}");
                    break;
                case LogSeverity.Debug:
                    Logger.Trace($"Discord.NET|{msg.Source}|{msg.Message}"); 
                    break;
                default:
                    Logger.Info($"Discord.NET|{msg.Source}|{msg.Message}");
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
