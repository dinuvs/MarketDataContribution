using MarketDataContribution.DataAccess.DbModel;
using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.DataAccess.Model.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.Tests.ModelTests.RepositoryTests
{
    [TestClass]
    public class MarketDataRepositoryTests
    {

        [TestMethod]
        public void WhenMarketDataIsRetrievedReturnsNonZeroListOfMarketData()
        {
            List<MarketData> marketDatasList = new()
            {
                new MarketData()
                {
                    MarketDataTypeId = 1,
                    FxCurrencyPairId = 1,
                    Bid = 1.123M,
                    Ask = 1.135M
                },
                new MarketData()
                {
                    MarketDataTypeId = 2,
                    FxCurrencyPairId = 2,
                    Bid = 1.155M,
                    Ask = 1.160M
                }

            };


            IQueryable<MarketData> queryableList = marketDatasList.AsQueryable();

            var mockSet = new Mock<DbSet<MarketData>>();
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());


            var mockDbContext = new Mock<IAppDbContext>();
            mockDbContext.Setup(m => m.MarketData).Returns(mockSet.Object);


           
            var marketDataRepository = new MarketDataRepository(mockDbContext.Object);
            var result =  marketDataRepository.GetAllMarketData().ToList();
            Assert.IsTrue(result.Count>0);
        }

        [TestMethod]
        public void WhenMarketDataTableIsEmptyIsRetrievedReturnsZeroListOfMarketData()
        {
            List<MarketData> marketDataList = new();

            IQueryable<MarketData> queryableList = marketDataList.AsQueryable();

            var mockSet = new Mock<DbSet<MarketData>>();
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());


            var mockDbContext = new Mock<IAppDbContext>();
            mockDbContext.Setup(m => m.MarketData).Returns(mockSet.Object);



            var marketDataRepository = new MarketDataRepository(mockDbContext.Object);
            var result = marketDataRepository.GetAllMarketData().ToList();
            Assert.IsTrue(result.Count == 0);
           
        }


        [TestMethod]
        public async Task WhenMarketDataAddedSuccesfullyReturnsMarketData()
        {
            List<MarketData> marketDatasList = new()
            {
                new MarketData()
                {
                    MarketDataTypeId = 1,
                    FxCurrencyPairId = 1,
                    Bid = 1.123M,
                    Ask = 1.135M
                },
                new MarketData()
                {
                    MarketDataTypeId = 2,
                    FxCurrencyPairId = 2,
                    Bid = 1.155M,
                    Ask = 1.160M
                }

            };


            IQueryable<MarketData> queryableList = marketDatasList.AsQueryable();

            var mockSet = new Mock<DbSet<MarketData>>();
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());


            var addMarketData = new MarketData()
            {
                MarketDataTypeId = 1,
                FxCurrencyPairId = 1,
                Bid = 1.123M,
                Ask = 1.135M
            };



            var mockDbContext = new Mock<IAppDbContext>();
            mockDbContext.Setup(m => m.MarketData).Returns(mockSet.Object);
            mockDbContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));

            var marketDataRepository = new MarketDataRepository(mockDbContext.Object);
            var result = await marketDataRepository.AddAsync(addMarketData);

            Assert.IsNotNull(result);
            Assert.AreEqual(addMarketData, result);
        }

        [TestMethod]
        public async Task WhenMarketDataAddErrorsReturnsNull()
        {
            List<MarketData> marketDatasList = new()
            {
                new MarketData()
                {
                    MarketDataTypeId = 1,
                    FxCurrencyPairId = 1,
                    Bid = 1.123M,
                    Ask = 1.135M
                },
                new MarketData()
                {
                    MarketDataTypeId = 2,
                    FxCurrencyPairId = 2,
                    Bid = 1.155M,
                    Ask = 1.160M
                }

            };


            IQueryable<MarketData> queryableList = marketDatasList.AsQueryable();

            var mockSet = new Mock<DbSet<MarketData>>();
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<MarketData>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());


            var addMarketData = new MarketData()
            {
                MarketDataTypeId = 1,
                FxCurrencyPairId = 1,
                Bid = 1.123M,
                Ask = 1.135M
            };

            

            var mockDbContext = new Mock<IAppDbContext>();
            mockDbContext.Setup(m => m.MarketData).Returns(mockSet.Object);

            var marketDataRepository = new MarketDataRepository(mockDbContext.Object);
            var result = await marketDataRepository.AddAsync(addMarketData);

            Assert.IsNull(result);
        }

    }
}
