using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ITransaction
    {
        string Ticker { get; }
        DateTime Created { get; }        
        int Units { get; }
        double UnitPrice { get; }
        string PriceCurrency { get; }
        double AbcToPriceCurrencyRate { get; }
    }

    public interface IPositionRepository
    {
        IEnumerable<ITransaction> GetPosition(int userId);
    }
}
