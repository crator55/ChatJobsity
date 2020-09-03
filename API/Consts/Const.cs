using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Consts;
namespace API.Consts
{
    public class Const
    {
        public Const()
        {
            CodeBot = "/stock=";
            BotName = "RabbitMQ";
            Url = "https://localhost:44315/bot/GetResponseBot";
        }

        public string CodeBot { get; set; }
        public string BotName { get; set; }
        public string Url { get; set; }
    }
}