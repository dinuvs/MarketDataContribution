using MarketDataContribution.DataAccess.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.Model.Repository
{
    public class MarketDataRepository : IMarketDataRepository
    {
        private readonly IAppDbContext _context;

        public MarketDataRepository(IAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MarketData> GetAllTransactions()
        {
            var marketDatas = _context.MarketData.Include("FxCurrencyPair").ToList();
            marketDatas = _context.MarketData.Include("MarketDataType").ToList();
            marketDatas = _context.MarketData.OrderByDescending(t => t.LastUpdated).ToList();
            return marketDatas;
        }

        public async Task<MarketData> AddAsync(MarketData marketData)
        {
            _context.MarketData.Add(marketData);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return marketData;
            }
            return null;
        }

    }
}
