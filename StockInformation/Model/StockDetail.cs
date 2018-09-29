using System;
using System.Collections.Generic;
using System.Text;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.Sharedkernel.Model;

namespace StockInformation
{
    public sealed class Stock : Entity<long>
    {
        public Stock(string stockName, string stockDescription, Dictionary<ExchangeTypeEnum, string> stockCodes)
        {
            StockName = stockName;
            StockDescription = stockDescription;
            StockCodes = stockCodes;
        }

        public string StockName { get; private set; }
        public string StockType { get; private set; }
        public string StockDescription { get; private set; }
        public Dictionary<ExchangeTypeEnum, string> StockCodes { get; private set; }
        public string PartitionKey { get { return $"{StockName}"; } }
    }
}
