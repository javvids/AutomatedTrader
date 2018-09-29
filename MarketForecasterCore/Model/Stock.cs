using AutomatedTrader.Sharedkernel.Enum;

namespace MarketForecasterCore.Model
{
    public class Stock
    {
        public Stock(string stockName, ExchangeTypeEnum exchange, string stockCode)
        {
            StockName = stockName;
            Exchange = exchange;
            StockCode = stockCode;
        }

        public string StockName { get;private set; }
        public ExchangeTypeEnum Exchange { get;private set; }
        public string StockCode { get;private set; }
        public string PartitionKey { get { return $"{StockCode}_{Exchange}"; } }


    }
}
