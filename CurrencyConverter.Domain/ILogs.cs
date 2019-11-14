using System;
using System.Collections.Generic;

namespace CurrencyConverter.Domain
{
    public interface ILogs
    {
        void Add(KeyValuePair<DateTime, decimal> entry);
        List<KeyValuePair<DateTime, decimal>> Get(DateTime logDate);
    }
}