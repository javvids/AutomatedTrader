using System;
using AutomatedTrader.Sharedkernel.Model;
using AutomatedTrader.SharedKernel;

namespace MarketForeCasterCore.Model
{
    public sealed class Quote:Entity<string>
    {
        
        public Quote(DateTime today, Double open, Double high, Double close, Double low)
        {
            Today = today;
            Open = open;
            High = high;
            Close = close;
            Low = low;

            Id = $"{today.ToShortDateString()}";
            TableName = Constants.QuoteTableName;
        }

        public DateTime Today{ get; private set; }
        public Double Open { get; private set; }
        public Double High { get; private set; }
        public Double Close { get; private set; }
        public Double Low { get; private set; }

    }
}
