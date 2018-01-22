using Domain.Common;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ProtfolioTracker.Repos
{
    public class PositionRepository : IPositionRepository
    {
        public IEnumerable<ITransaction> GetPosition(int userId)
        {
            List<ITransaction> position = new List<ITransaction>();
            position.Add(new Transaction() { Created=DateTime.UtcNow.AddDays(20),Units=12,Ticker="112540",PriceCurrency="ILS",UnitPrice=1.21,AbcToPriceCurrencyRate=1});
            position.Add(new Transaction() { Created = DateTime.UtcNow.AddDays(20), Units = 5, Ticker = "VOO", PriceCurrency = "USD", UnitPrice = 112, AbcToPriceCurrencyRate = 3.5 });
            position.Add(new Transaction() { Created = DateTime.UtcNow.AddYears(-1), Units = 15, Ticker = "112540", PriceCurrency = "ILS", UnitPrice = 1.15, AbcToPriceCurrencyRate = 1 });
            position.Add(new Transaction() { Created = DateTime.UtcNow.AddYears(-1), Units = 5, Ticker = "VOO", PriceCurrency = "USD", UnitPrice = 85, AbcToPriceCurrencyRate = 3.5 });


            return position;
        }
    }

    
}
