using System;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Core;
using AutomatedTrader.Sharedkernel.Enum;
using AutomatedTrader.SharedKernel;
using MarketForecasterCore.BusinessLogic;
using MarketForeCasterCore.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketForecasterCore.Tests
{
    [TestClass]
    public class ROCIndicatorCalculationTest
    {
        [TestInitialize]
        public void Initialize()
        {
            
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.Load("MarketForecasterCore"));
            //builder.RegisterType<ROCIndicatorCalculation>().As<ITechnicalIndicatorCalculation<ROCLists, ROCIndicator>>();
            
            _container=builder.Build(Autofac.Builder.ContainerBuildOptions.IgnoreStartableComponents);
            

        }

        private IContainer _container;
        private ROCLists _rocLists;

        [TestMethod]
        public void Calculate_ROCIndicators()
        {
            _rocLists = new ROCLists();
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 1), 0, 0, 7954.9, 0,ExchangeTypeEnum.NSE ), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 2), 0, 0, 7931.35, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 3), 0, 0, 7864.15, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 4), 0, 0, 7781.9, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 7), 0, 0, 7765.4, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 8), 0, 0, 7701.7, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 9), 0, 0, 7612.5, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 10), 0, 0, 7683.3, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 11), 0, 0, 7610.45, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 14), 0, 0, 7650.05, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 15), 0, 0, 7700.9, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 16), 0, 0, 7750.9, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 17), 0, 0, 7844.35, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 18), 0, 0, 7761.95, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 21), 0, 0, 7834.45, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 22), 0, 0, 7786.1, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 23), 0, 0, 7865.95, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 24), 0, 0, 7861.05, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 28), 0, 0, 7925.15, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 29), 0, 0, 7928.95, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 30), 0, 0, 7896.25, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2015, 12, 31), 0, 0, 7946.35, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2016, 01, 01), 0, 0, 7963.2, 0,ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2016, 01, 04), 0, 0, 7791.3, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2016, 01, 04), 0, 0, 7784.65, 0, ExchangeTypeEnum.NSE), null));
            _rocLists.Add(ROCIndicator.Create(0, 0, 0, new Quote(new DateTime(2016, 01, 06), 0, 0, 7741, 0, ExchangeTypeEnum.NSE), null));

            var stringBuilder = new StringBuilder();
            _rocLists.Foreach((item) =>
            {
                if(item.TriggerDetail!=null)
                    stringBuilder.Append($"{item.Quote.Today},{item.Quote.Close}, {item.ROC14Days}, {item.EMA9Day},{item.ROCOnEMA9Day}, {item.TriggerDetail.TradeType}, {item.TriggerDetail.TriggeredPrice},{item.TriggerDetail.IsTriggered},{System.Environment.NewLine}");
            });

            File.WriteAllText(@"RocCalculation1.csv", stringBuilder.ToString());
         }
    }
}
