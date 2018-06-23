using System;
using AutomatedTrader.Sharedkernel.Model;

namespace MarketForeCasterCore.Model
{
    public sealed class Quote:Entity<long>
    {
        public Quote(DateTime today, Double open, Double high, Double close, Double low)
        {
            Today = today;
            Open = open;
            High = high;
            Close = close;
            Low = low;
        }

        public DateTime Today{ get; private set; }
        public Double Open { get; private set; }
        public Double High { get; private set; }
        public Double Close { get; private set; }
        public Double Low { get; private set; }

    }
}
