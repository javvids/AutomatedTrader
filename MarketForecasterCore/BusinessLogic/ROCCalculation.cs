using MarketForeCasterCore.Model;
using System.Collections.Generic;

namespace MarketForecasterCore.BusinessLogic
{
    public static class ROCCalculation
    {
        public static double CalculcateRocR(IList<Quote> quotes, int rocrDay, int index)
        {
            if (index < rocrDay)
                return 0;
            
            var prevPrice = quotes[index - rocrDay].Close;

            var currentPrice = quotes[index].Close;

            var roC14 = ((currentPrice - prevPrice) / prevPrice) * 100;

            return roC14;

        }
    }
}