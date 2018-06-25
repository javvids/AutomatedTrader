using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.Sharedkernel.Model;
using AutomatedTrader.SharedKernel;

namespace AutomatedTrader.MarketMonitor
{
    public class TradeStock:Entity<string>
    {
        public string StockName { get; set; }
        public string StockCode { get; set; }
        public StockExchangeEnum Exchange { get; set; }

        public static TradeStock Create(string stockName, string stockCode, StockExchangeEnum exchange)
        {
            Guard.IsNull<string>(stockName, "StockName cannot be null or empty");
            Guard.IsNull<string>(stockCode, "StockName cannot be null or empty");

            var stockDetail = new TradeStock()
            {
                StockName = stockName,
                StockCode = stockCode,
                Exchange = exchange,
                Id = stockCode,
                TableName = Constants.QuoteTableName
            };
            
            return stockDetail;
        }
    }
}
