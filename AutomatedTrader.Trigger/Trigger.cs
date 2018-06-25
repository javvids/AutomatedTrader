using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutomatedTrader.MarketMonitor;
using AutomatedTrader.Sharedkernel.Enum;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AutomatedTrader.Trigger
{
    public static class Trigger
    {
        private static string _baseUrl= "https://www.nseindia.com/products/dynaContent/equities/indices/historicalindices.jsp?indexType={0}&fromDate={1}&toDate={2}";

        [FunctionName("Trigger")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            var stocks=FetchStockToMonitor();

            foreach (var stock in stocks)
            {
                var quote=GetQuote(stock);
            }
        }

        private static IEnumerable<TradeStock> FetchStockToMonitor()
        {
            var tradeStocks = new List<TradeStock>();
            tradeStocks.Add(TradeStock.Create("NIFTY", "NIFTY", StockExchangeEnum.NSE));

            return tradeStocks;
        }

        private static async Task<Quote> GetQuote(TradeStock tradeStock)
        {
            Quote quote=null;

            Uri url = new Uri(string.Format(_baseUrl, "NIFTY", DateTime.Today.ToString("dd-MM-YYYY"), DateTime.Today.ToString("dd-MM-YYYY")));
            HttpClient client = new HttpClient();
            client.BaseAddress = url;
            var response = client.GetAsync(url);

            await response.ContinueWith((responseData) => 
            {
                if (responseData.IsCompleted)
                {
                    quote= ParseContent(responseData.Result.Content);
                }
            });

            return quote;
        }

        private static Quote ParseContent(HttpContent content)
        {
            return new Quote(DateTime.Today,0,0,8900,0);
        }
    }
}
