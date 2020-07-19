using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace TomBot_Sharp.Services
{
    public class CustomCommandHandler
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        private Dictionary<String, String> _commands;
        private DiscordSocketClient _discord;

        public CustomCommandHandler(DiscordSocketClient discord)
        {
            _discord = discord;
            _commands = new Dictionary<String, String>();
            LoadCommands();
        }

        public void LoadCommands()
        {
            Logger.Info("Loading Custom Commands");
            String rawJson = File.ReadAllText("CustomCommands.json");
            _commands = JsonConvert.DeserializeObject<Dictionary<String, String>>(rawJson);
            foreach (var kv in _commands)
            {
                Logger.Info($"Loaded command {kv.Key} with action {kv.Value}");
            }
        }

        public void SaveCommands()
        {

        }

        public async Task MessageReceived(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            int argPos = 0;
            if (!message.Content.StartsWith("!")) return;
            var context = new SocketCommandContext(_discord, message);
            String commandToRun = message.Content.Replace("!", "");

            if (_commands.ContainsKey(commandToRun))
            {
                await context.Channel.SendMessageAsync(_commands[commandToRun]);
            }
            
            
        }
    }
}