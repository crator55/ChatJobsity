using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace API.botAi
{
    public class BotAiResponse : IStockGetter
    {
        public string GetResponseBot(string message)
        {
             HttpClient Client = new HttpClient();
            using (HttpResponseMessage response = Client.GetAsync($"https://stooq.com/q/l/?s={message}&f=sd2t2ohlcv&h&e=csv").Result)
            using (HttpContent content = response.Content)
            {
                var callResponse = content.ReadAsStringAsync().Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new ArgumentException(callResponse);
                var data = callResponse.Substring(callResponse.IndexOf(Environment.NewLine, StringComparison.Ordinal) + 2);
                StockModels stock = ParseResponse(data);
                if (stock.Symbol.Equals(message.ToUpper()))
                {
                    return $"{stock.Symbol} quote is ${stock.Close} per share";
                }
            }
            return "No command founded.";
        }
        public StockModels ParseResponse(string data)
        {
            var fields = data.Split(',');
            StockModels stock = new StockModels()
            {
                Symbol = fields[0],
                Date = !fields[1].Contains("N/D") ? DateTime.Parse(fields[1]) : default,
                Time = !fields[2].Contains("N/D") ? TimeSpan.Parse(fields[2]) : default,
                Open = !fields[3].Contains("N/D") ? decimal.Parse(fields[3]) : default,
                High = !fields[4].Contains("N/D") ? decimal.Parse(fields[4]) : default,
                Low = !fields[5].Contains("N/D") ? decimal.Parse(fields[5]) : default,
                Close = !fields[6].Contains("N/D") ? decimal.Parse(fields[6]) : default,
                Volume = !fields[7].Contains("N/D") ? Int32.Parse(fields[7]) : default
            };
            return stock;
        }
    }

}