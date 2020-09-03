using API.botAi;
using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsAPI
{
    [TestClass]
    public class BotAi
    {
        [TestMethod]
        public void GetResponseBot_BotGetsStockValue_ReturnString()
        {
            string stock = "aapl.us";
            BotAiResponse botAiResponse = new BotAiResponse();
            string resul = botAiResponse.GetResponseBot(stock);
            Assert.IsNotNull(resul);
        }
        [TestMethod]
        public void GetResponseBot_BotGetsStockNameWrong_ReturnStringEmpty()
        {
            string stock = "qwes";
            BotAiResponse botAiResponse = new BotAiResponse();
            string resul = botAiResponse.GetResponseBot(stock);
            Assert.IsNotNull(resul);
        }
        [TestMethod]
        public void ParseResponse_ParseRecievCSV_ReturnString()
        {
            string stock = "AAPL.US, 28 / 08 / 2020, 18:56:24,504.05,505.04,499.43,501.3,12127197";
            BotAiResponse botAiResponse = new BotAiResponse();
            StockModels resul = botAiResponse.ParseResponse(stock);
            Assert.IsNotNull(resul);
        }
    }
}
