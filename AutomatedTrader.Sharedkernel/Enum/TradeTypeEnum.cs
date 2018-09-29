using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTrader.Sharedkernel.Enum
{
    public enum ActionTypeEnum
    {
        Buy,
        Sell,
        ShortSell
    }

    public enum ExchangeTypeEnum
    {
        BSE,
        NSE
    }

    public enum StockTypeEnum
    {
        Equity,
        Index,
        Currency,
        Commodity
    }

    public enum TradeTypeEnum
    {
        Equity,
        Futures,
        Options
    }

}
