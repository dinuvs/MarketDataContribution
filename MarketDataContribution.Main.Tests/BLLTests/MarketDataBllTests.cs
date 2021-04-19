using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.Main.BLL;
using MarketDataContribution.ValidationService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarketDataContribution.Main.Tests.BLLTests
{
    [TestClass]
    public class MarketDataBllTests
    {

        [TestMethod]
        public void WhenValidateFxQuoteWithNonNegativeValuesReturnsNoError()
        {


            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = 1.112M,
                Ask = 1.113M
            };
            Mock < IMarketDataValidationService > _mockMarketDataValidationService= new();

            _mockMarketDataValidationService.Setup(m => m.ValidateFxBidAndAsk(It.IsAny<MarketData>())).Returns(true);

            MarketDataBll marketDataBll = new(_mockMarketDataValidationService.Object);
            marketDataBll.ValidationServiceBasedOnMarketDataType(marketData);

            Assert.IsTrue(string.IsNullOrEmpty(marketData.Error));


        }

        [TestMethod]
        public void WhenValidateFxQuoteWithNegativeValuesReturnsErrorMessage()
        {


            MarketData marketData = new()
            {
                MarketDataTypeId = 3,
                Bid = -1.112M,
                Ask = 1.113M
            };
            Mock<IMarketDataValidationService> _mockMarketDataValidationService = new();

            _mockMarketDataValidationService.Setup(m => m.ValidateFxBidAndAsk(It.IsAny<MarketData>())).Returns(false);

            MarketDataBll marketDataBll = new(_mockMarketDataValidationService.Object);
            marketDataBll.ValidationServiceBasedOnMarketDataType(marketData);

            Assert.IsFalse(string.IsNullOrEmpty(marketData.Error));

        }

    }
}
