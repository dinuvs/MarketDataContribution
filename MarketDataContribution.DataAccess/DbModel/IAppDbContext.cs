using MarketDataContribution.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.DbModel
{
    public interface IAppDbContext
    {

        DbSet<FxCurrencyPair> FxCurrencyPair { get; set; }

        DbSet<MarketDataType> MarketDataType { get; set; }

        DbSet<MarketData> MarketData { get; set; }

        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
    }
}
