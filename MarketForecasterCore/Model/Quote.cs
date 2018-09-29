using System;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.Sharedkernel.Model;
using MarketForecasterCore.Model;

namespace MarketForeCasterCore.Model
{
    public sealed class Quote:Entity<long>
    {
        public Quote(DateTime today, Double open, Double high, Double close, Double low, Stock stock)
        {
            Today = today;
            Open = open;
            High = high;
            Close = close;
            Low = low;
            Stock= stock;
        }

        public Stock Stock { get; private set; }
        public DateTime Today{ get; private set; }
        public Double Open { get; private set; }
        public Double High { get; private set; }
        public Double Close { get; private set; }
        public Double Low { get; private set; }
        public string PartitionKey { get { return $"{Today.ToString("dd-MM-yyyy")}_{Stock.PartitionKey}"; } }
    }


}
