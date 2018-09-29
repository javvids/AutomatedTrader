using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.SharedKernel;
using MarketForecasterCore.BusinessLogic;
using System.Linq;

namespace MarketForeCasterCore.Model
{
    public sealed class ROCLists : IndicatorList<ROCIndicator>
    {        
        public override void Caclulate(int index)
        {
            Guard.IsNullOrEmpty<ROCIndicator>(this, "ROCIndicator list is empty");
            CalculateRocR14Days(this, index);
            CalculateEMA9Day(this, index);
            CalculateRocROn9DayEMA(this, index);

            EvaluateTrigger(this, index);
        }

        private ROCLists CalculateRocR14Days(ROCLists indicators, int index)
        {
            var rocr14=ROCCalculation.CalculcateRocR(indicators.Select(x => x.Quote.Close).ToList(), 14, index);
            indicators[index].SetROC14Day(rocr14);
            return indicators;
        }

        private ROCLists CalculateEMA9Day(ROCLists indicators, int index)
        {
            if (index < 11)
                return indicators;

            if (index == 11)
            {
                var average = indicators.Take(11).Average(x => x.Quote.Close);
                indicators[index].SetEMA9Day(average);
                return indicators;
            }

            var ema11Day = EMACalculation.CalculcateEMA(indicators.Select(x => x.EMA9Day==0?x.Quote.Close:x.EMA9Day)
                                .ToList(), 9, index);

            indicators[index].SetEMA9Day(ema11Day);

            return indicators;
        }

        private ROCLists CalculateRocROn9DayEMA(ROCLists indicators, int index)
        {
            var emaList= indicators.Select(x => x.EMA9Day)
                                .ToList();

            if (indicators.Where(z => z.EMA9Day > 0).Count() <= 9)
                return indicators;

            var rocrOn9DayEMA = ROCCalculation.CalculcateRocR(emaList, 9, index);

            indicators[index].SetRocOn9DayEMA(rocrOn9DayEMA);

            return indicators;
        }

        public ROCLists EvaluateTrigger(ROCLists indicators, int index)
        {
            if (indicators[index].EMA9Day <= 0)
                return indicators;

            var tradeType = indicators[index].ROC14Days > indicators[index].ROCOnEMA9Day ? ActionTypeEnum.Buy : ActionTypeEnum.Sell;

            var isTriggered = indicators[index - 1].TriggerDetail == null || indicators[index - 1].TriggerDetail.TradeType == tradeType ? false : true;

            indicators[index].SetTriggerDetail(TriggerDetail.Create(isTriggered, indicators[index].Quote.Today, indicators[index].Quote.Close, tradeType));

            return indicators;
        }
    }
}
