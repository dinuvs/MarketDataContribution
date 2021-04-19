using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.ValidationService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.ValidationService.Tests.Services
{
    [TestClass]
    public class MarketDataValidationServiceTests
    {

        [TestMethod]
        public void WhenNegativeFxQuoteBidReturnsFalse()
        {
            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = -1.112M,
                Ask = 1.113M
            };
            IMarketDataValidationService marketDataValidationService = new MockMarketDataValidationService();
            var result=marketDataValidationService.ValidateFxBidAndAsk(marketData);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void WhenNegativeFxQuoteAskReturnsFalse()
        {
            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = 1.112M,
                Ask = -1.113M
            };
            IMarketDataValidationService marketDataValidationService = new MockMarketDataValidationService();
            var result = marketDataValidationService.ValidateFxBidAndAsk(marketData);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenNegativeFxQuoteBidAndAskReturnsFalse()
        {
            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = -1.112M,
                Ask = -1.113M
            };
            IMarketDataValidationService marketDataValidationService = new MockMarketDataValidationService();
            var result = marketDataValidationService.ValidateFxBidAndAsk(marketData);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void WhenPositiveFxQuoteBidReturnsTrue()
        {
            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = 1.112M
            };
            IMarketDataValidationService marketDataValidationService = new MockMarketDataValidationService();
            var result = marketDataValidationService.ValidateFxBidAndAsk(marketData);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void WhenPositiveFxQuoteAskReturnsTrue()
        {
            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Ask = 1.113M
            };
            IMarketDataValidationService marketDataValidationService = new MockMarketDataValidationService();
            var result = marketDataValidationService.ValidateFxBidAndAsk(marketData);
            Assert.IsTrue(result);

        }

    }
}
