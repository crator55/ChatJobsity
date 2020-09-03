using API.botAi;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace API.Controllers
{

    [Authorize]
    public class BotController : Controller
    {

        [HttpPost]
        [AllowAnonymous]

        public string  GetResponseBot(BotModels bot)
        {
            BotAiResponse botAiResponse = new BotAiResponse();
            string result = botAiResponse.GetResponseBot(bot.Command);
            return result;

        }
    }
}
