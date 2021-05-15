using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace NerdBot.Services
{
  public class InStatus
  {
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    private DiscordSocketClient _discord;
    public InStatus(DiscordSocketClient discord)
    {
      _discord = discord;
    }

    public async Task ConnectEvent() {
      Logger.Info(Environment.GetEnvironmentVariable("InStatusURL"));
      var httpWebRequest = (HttpWebRequest)WebRequest.Create(Environment.GetEnvironmentVariable("InStatusURL"));
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = "POST";
      using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
      {
          string json = "{\"trigger\": \"up\", \"status\":\"OPERATIONAL\"}"; // It's ok
          streamWriter.Write(json);
      }
      HttpWebResponse httpWebResponse = await httpWebRequest.GetResponseAsync() as HttpWebResponse;
    }
    public async Task DisconnectEvent(Exception arg) {
      Logger.Info(Environment.GetEnvironmentVariable("InStatusURL"));
      var httpWebRequest = (HttpWebRequest)WebRequest.Create(Environment.GetEnvironmentVariable("InStatusURL"));
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = "POST";
      using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
      {
          string json = "{\"trigger\": \"down\",\"status\": \"MAJOROUTAGE\"}"; // It's not ok
          streamWriter.Write(json);
      }
      HttpWebResponse httpWebResponse = await httpWebRequest.GetResponseAsync() as HttpWebResponse;
    }
  }
}
