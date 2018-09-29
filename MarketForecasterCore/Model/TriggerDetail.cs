using System;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.Sharedkernel.Model;

namespace MarketForeCasterCore.Model
{
    public class TriggerDetail: Entity<long>
    {
        public static TriggerDetail Create(bool isTriggered, DateTime triggerTime, double triggeredPrice, ActionTypeEnum tradeType)
        {
            var triggerDetail = new TriggerDetail() {
                IsTriggered = isTriggered,
                TriggerTime = triggerTime,
                TriggeredPrice = triggeredPrice,
                TradeType = tradeType
        };

        return triggerDetail;
        }

        public bool IsTriggered { get; protected set; }
        public DateTime TriggerTime { get; protected set; }
        public double TriggeredPrice { get; protected set; }
        public ActionTypeEnum TradeType { get; protected set; }

       
    }
}
