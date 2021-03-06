﻿using MarketForeCasterCore.Model;
using System.Collections.Generic;

namespace MarketForecasterCore.BusinessLogic
{
    public static class ROCCalculation
    {
        public static double CalculcateRocR(IList<double> lastPrice, int rocrDay, int index)
        {
            if (index < rocrDay)
                return 0;
            
            var prevPrice = lastPrice[index - rocrDay];

            var currentPrice = lastPrice[index];

            var roC14 = ((currentPrice - prevPrice) / prevPrice) * 100;

            return roC14;

        }
    }
}