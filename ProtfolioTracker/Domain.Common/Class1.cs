using Domain.Interfaces;
using System;

namespace Domain.Common
{
    public class Transaction : ITransaction
    {
        public string Ticker { get; set;}

        public DateTime Created { get; set;}

        public int Units { get; set;}

        public double UnitPrice { get; set;}

        public string PriceCurrency { get; set;}

        public double AbcToPriceCurrencyRate { get; set;}
    }
}
