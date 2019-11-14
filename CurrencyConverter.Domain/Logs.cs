using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Domain
{
    public class Logs : ILogs
    {
        public List<KeyValuePair<DateTime, decimal>> InMemory { get; set; }

        public Logs()
        {
            InMemory = new List<KeyValuePair<DateTime, decimal>>();
        }

        public void Add(KeyValuePair<DateTime, decimal> entry)
        {
            InMemory.Add(entry);
        }

        public List<KeyValuePair<DateTime, decimal>> Get(DateTime logDate)
        {
            if (logDate == default)
            {
                throw new ArgumentNullException($"{nameof(logDate)} can not be null or default");
            }
            return InMemory.Where(x => x.Key == logDate).ToList();
        }
    }
}