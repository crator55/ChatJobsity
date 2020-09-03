using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using API.Consts;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace API
{
    public class ChatHub : Hub
    {
        readonly Const @const = new Const();
        static readonly HttpClient client = new HttpClient();
        public async Task Send(string name, string message)
        {
            if (message.Contains(@const.CodeBot))
            {
                string botMessage = message.Replace(@const.CodeBot, "");
                string result = await GetValueStock(botMessage);
                Clients.All.broadcastMessage(@const.BotName, result);
            }
            else
            {
                Clients.All.broadcastMessage(name, message);
            }
        }

        private async Task<string> GetValueStock(string botMessage)
        {
            try
            {
                var newJson = new { Command = botMessage };
                var json = JsonConvert.SerializeObject(newJson);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = @const.Url;
                var client = new HttpClient();
                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}