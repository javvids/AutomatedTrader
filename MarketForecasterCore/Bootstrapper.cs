using System.Reflection;
using Autofac;

namespace MarketForecasterCore
{
    public static class Bootstrapper
    {
        public static readonly Autofac.IContainer Container;

        static Bootstrapper()
        {
            var builder = new ContainerBuilder();
            RegisterComponents(builder);
            Container = builder.Build();
        }

        public static void RegisterComponents(ContainerBuilder container)
        {
            container.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            //container.RegisterType<ROCIndicatorCalculation>().As<ITechnicalIndicatorCalculation<ROCLists, ROCIndicator>>();
            
        }
    }
}
