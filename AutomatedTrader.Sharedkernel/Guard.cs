using System;
using System.Collections.Generic;

namespace AutomatedTrader.SharedKernel
{

    public static class Guard
    {
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void IsNullOrEmpty<T>(IEnumerable<T> guardValue, string errorMessage)
        {
            if (guardValue.IsNullOrEmpty())
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void IsNullOrEmpty<T,TValue>(IDictionary<T,TValue> guardValue, string errorMessage)
        {
            if (guardValue.IsNullOrEmpty())
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }

    
}


