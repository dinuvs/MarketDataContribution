using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.Model.Repository
{
    public interface IMarketDataRepository
    {
        IEnumerable<MarketData> GetAllMarketData();
        Task<MarketData> AddAsync(MarketData marketData);
    }
}
