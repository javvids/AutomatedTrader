using System;
using AutomatedTrader.Sharedkernel.Enum;

namespace MarketForeCasterCore.Model
{

    public sealed class ROCIndicator : Indicator
    {
        public static ROCIndicator Create(double eMA9Day, double eMA12Day,double rOCOnEMA9Day,
            Quote market, TriggerDetail triggerDetail)
        {

            var macd = new ROCIndicator()
            {
                ROC14Days = eMA9Day,
                EMA9Day = eMA12Day,
                ROCOnEMA9Day= rOCOnEMA9Day,
                Quote =market,
                TriggerDetail =triggerDetail
            };
            
            return macd;
        }

        public void SetTriggerDetail(TriggerDetail triggerDetail)
        {
            TriggerDetail = triggerDetail;
        }
       
        public double ROC14Days { get; private set; }
        public double EMA9Day { get; private set; }
        public double ROCOnEMA9Day { get; private set; }

        public void SetROC14Day(double roc14Day)
        {
            ROC14Days = roc14Day;
        }

        public void SetEMA9Day(double eMA9Day)
        {
            EMA9Day = eMA9Day;
        }

        public void SetRocOn9DayEMA(double rOCOnEMA9Day)
        {
            ROCOnEMA9Day = rOCOnEMA9Day;
        }

         
    }
}
