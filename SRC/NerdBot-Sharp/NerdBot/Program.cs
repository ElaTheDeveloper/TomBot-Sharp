﻿using System;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Net;

using NLog.Fluent;

using DotNetEnv;
using NerdBot.Services;


namespace NerdBot
{
    class Program
    {
        
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private DiscordSocketClient _client;
        private RandomQuotePicker _randomQuotePicker;
        private CommandService _commands;
        private CustomCommandHandler _customCommandHandler;
        private InStatus _InStatus;
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            new Program().MainAsync().GetAwaiter().GetResult();
        }


        public async Task MainAsync()
        {
            Logger.Info("NerdBot MainAsync() Started");
            _client = new DiscordSocketClient();
            _client.Log += Log;

            _commands = new CommandService();
            _randomQuotePicker = new RandomQuotePicker();
            _InStatus = new InStatus(_client);

            _client.MessageReceived += _randomQuotePicker.MessageReceived;
            if(Environment.GetEnvironmentVariable("InStatusURL") != null && Environment.GetEnvironmentVariable("InStatusURL") != "")
            {
                _client.Connected +=_InStatus.ConnectEvent;
                _client.Disconnected += _InStatus.DisconnectEvent;
            }
          
            
            _customCommandHandler = new CustomCommandHandler(_client);
            _client.MessageReceived += _customCommandHandler.MessageReceived;
            
            var services = ConfigureServices();
            await services.GetRequiredService<CommandHandler>().InitializeAsync(services);
            
            Logger.Info("Using Discord Token: " + Environment.GetEnvironmentVariable("DiscordToken"));
            Logger.Info("Logging into Discord now!");
            await _client.LoginAsync(TokenType.Bot, 
                Environment.GetEnvironmentVariable("DiscordToken"));
            
            
            await _client.StartAsync();

            
            
            
            // Block this task until the program is closed.
            await Task.Delay(-1);
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

        private IServiceProvider ConfigureServices()
        {
            Logger.Info("Configuring servies");
            return new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandler>()
                .BuildServiceProvider();
        }
        
        
    }
}
