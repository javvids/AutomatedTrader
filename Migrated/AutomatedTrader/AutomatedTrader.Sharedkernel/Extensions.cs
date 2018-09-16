using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTrader.SharedKernel
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)  
        {
            if(source==null || !source.Any<T>())
            {
                return true;
            }
            return false;
        }

        public static void Foreach<T>(this IEnumerable<T> source,Action<T> method)
        {
            foreach (var item in source)
            {
                method.Invoke(item);
            }
        }
         
    }


    
}


