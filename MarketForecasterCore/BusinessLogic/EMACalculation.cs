using MarketForeCasterCore.Model;
using System.Collections.Generic;

namespace MarketForecasterCore.BusinessLogic
{
    public static class EMACalculation
    {
        public static double CalculcateEMA(IList<double> lastPrice, int emaDay, int index)
        {
            if (index < emaDay)
                return 0;

            var prevPrice = lastPrice[index - 1];

            var currentPrice = lastPrice[index];

            var ema = currentPrice * (double)(2/(double)(emaDay+1)) + prevPrice * (double)(1 - (double)(2 /(double) (emaDay + 1)));

            return ema;

        }
    }
}