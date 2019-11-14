using System;
using System.Collections.Generic;

namespace CurrencyConverter.Domain
{
    public class Currency : ICurrency
    {
        private readonly ILogs _logs;

        public Currency(ILogs logs)
        {
            _logs = logs;
        }
        public decimal PoundToDollar(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Amount can not be less than or equal zero");
            }

            var value = Convert.ToDecimal(amount * Constants.DollarRate);

            var entryDate = new DateTime(2019, 01, 01);

            _logs.Add(new KeyValuePair<DateTime, decimal>(entryDate, value));
           
            return value;
        }

        public decimal PoundToAud(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Amount can not be less than or equal zero");
            }

            var value = Convert.ToDecimal(amount * Constants.AudRate);

            var entryDate = new DateTime(2020, 01, 01);

            _logs.Add(new KeyValuePair<DateTime, decimal>(entryDate, value));

            return value;
        }

        public decimal PoundToEuro(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"Amount can not be less than or equal zero");
            }

            var value = Convert.ToDecimal(amount * Constants.EurRate);

            var entryDate = new DateTime(2019, 01, 01);

            _logs.Add(new KeyValuePair<DateTime, decimal>(entryDate, value));

            return value;
        }
    }
}
