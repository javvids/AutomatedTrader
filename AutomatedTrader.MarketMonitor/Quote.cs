using System;
using AutomatedTrader.Sharedkernel.Model;

namespace AutomatedTrader.MarketMonitor
{
    public class Quote:ValueObject<Quote>
    {
        public DateTime Today { get; private set; }
        public double Open  { get; private set; }
        public double High { get; private set; }
        public double Low { get; private set; }
        public double Close{ get; private set; }

        public Quote(DateTime today,double open, double high, double close, double low)
        {
            Today = today;
            Open=open;
            High = high;
            Close = close;
            Low = low;
        }
    }
}
