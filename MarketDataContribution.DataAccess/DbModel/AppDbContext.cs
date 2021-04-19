using MarketDataContribution.DataAccess.DbModel.Extensions;
using MarketDataContribution.DataAccess.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.DbModel
{
    public class AppDbContext:IdentityDbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<FxCurrencyPair> FxCurrencyPair { get; set; }

        public DbSet<MarketDataType> MarketDataType { get; set; }

        public DbSet<MarketData> MarketData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initial MarketDataType(Fxquote, Legal auditing) and FxCurrencyPair(EUR/USD, GBP/USD) entries
            //API end points needs to be built for adding new MarketDataTypes and FxCurrencyPairs and listing the Refdata
            modelBuilder.Seed();
        }
    }
}
