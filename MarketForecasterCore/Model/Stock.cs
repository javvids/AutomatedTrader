using System.Collections.Generic;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.Sharedkernel.Model;
using AutomatedTrader.SharedKernel;

namespace MarketForeCasterCore.Model
{
    public sealed class Stock : Entity<long>
    {
        public Stock(string stockName, string stockDescription, Dictionary<ExchangeTypeEnum,string> stockCodes)
        {
            StockName = stockName;
            StockDescription = stockDescription;
            StockCodes= stockCodes;
        }

        public string StockName { get; private set; }
        public string StockDescription { get; private set; }
        public Dictionary<string, Quote> StockQuotes { get; private set;}
        public Dictionary<ExchangeTypeEnum, string> StockCodes { get; private set; }
        public string PartitionKey { get { return $"{StockName}"; } }

        public void AddStockQuotes(IEnumerable<Quote> stockQuotes)
        {
            Guard.IsNullOrEmpty<Quote>(stockQuotes, "StockQuotes is null or empty");
            StockQuotes = StockQuotes ?? new Dictionary<string, Quote>();

            foreach (var quote in stockQuotes)
            {
                StockQuotes.Add(quote.PartitionKey, quote);
            }
        }

    }


}
