using MarketForeCasterCore.Model;
using System.Collections.Generic;

namespace MarketForecasterCore.BusinessLogic
{
    public static class EMACalculation
    {
        public static double CalculcateEMA(IList<Quote> quotes, int emaDay, int index)
        {
            if (index < emaDay)
                return 0;

            var prevPrice = quotes[index - 1].Close;

            var currentPrice = quotes[index].Close;

            var ema = currentPrice * (double)(2/(double)(emaDay+1)) + prevPrice * (double)(1 - (double)(2 /(double) (emaDay + 1)));

            return ema;

        }
    }
}