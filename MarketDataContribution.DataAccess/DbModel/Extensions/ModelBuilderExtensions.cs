using MarketDataContribution.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace MarketDataContribution.DataAccess.DbModel.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketDataType>().HasData(
                new MarketDataType
                {
                    MarketDataTypeId = 3,
                    MarketTypeName = "FxQuote",
                    LastUpdatedBy = "System",
                    LastUpdated = DateTime.Now
                },
                new MarketDataType
                {

                    MarketDataTypeId = 4,
                    MarketTypeName = "Legal auditing",
                    LastUpdatedBy = "System",
                    LastUpdated = DateTime.Now
                }
                ) ;

            modelBuilder.Entity<FxCurrencyPair>().HasData(
               new FxCurrencyPair
               {
                   FxCurrencyPairId = 1,
                   FxCurrencyPairName = "EUR/USD",
                   LastUpdatedBy = "System",
                   LastUpdated = DateTime.Now
               },
               new FxCurrencyPair
               {
                   FxCurrencyPairId = 2,
                   FxCurrencyPairName = "USD/EUR",
                   LastUpdatedBy = "System",
                   LastUpdated = DateTime.Now
               },
               new FxCurrencyPair
               {
                    FxCurrencyPairId = 3,
                    FxCurrencyPairName = "GBP/USD",
                    LastUpdatedBy = "System",
                    LastUpdated = DateTime.Now
               },
               new FxCurrencyPair
               {
                   FxCurrencyPairId = 4,
                   FxCurrencyPairName = "USD/GBP",
                   LastUpdatedBy = "System",
                   LastUpdated = DateTime.Now
               }
               );

        }

    }
}
