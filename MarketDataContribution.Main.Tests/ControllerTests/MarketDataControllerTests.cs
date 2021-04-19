using AutoMapper;
using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.DataAccess.Model.Repository;
using MarketDataContribution.Main.BLL;
using MarketDataContribution.Main.Controllers;
using MarketDataContribution.Main.Dtos;
using MarketDataContribution.Main.Utils;
using MarketDataContribution.ValidationService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Tests.ControllerTests
{
    [TestClass]
    public class MarketDataControllerTests
    {
        [TestMethod]
        public void GetAllMarketDataListReturnsNonZeroList()
        {
            List<MarketData> marketDatas = new()
            {
                new MarketData()
                {
                    MarketDataTypeId = 1,
                    FxCurrencyPairId = 1,
                    Bid = 1.1243M,
                    Ask = 1.1300M
                }
            };

            List<MarketDataDto> marketDataDtos = new()
            {
                new MarketDataDto()
                {
                    MarketDataTypeId = 1,
                    FxCurrencyPairId = 1,
                    Bid = 1.1243M,
                    Ask = 1.1300M
                }
            };

            Mock<IMarketDataRepository> mockMarketDataRepository = new();

            mockMarketDataRepository.Setup(m => m.GetAllMarketData()).Returns(marketDatas.AsEnumerable());

            Mock<IMapper> mockMapper = new();
            mockMapper.Setup(m => m.Map<IEnumerable<MarketDataDto>>(It.IsAny<IEnumerable<MarketData>>())).Returns(marketDataDtos);

            Mock<IMarketDataBll> mockMarketDataBll = new();

            Mock<IObjectJsonConverter> mockObjJson = new();

            var marketDataController = new MarketDataController(new NullLogger<MarketDataController>(), mockMarketDataRepository.Object, mockMapper.Object, mockMarketDataBll.Object, mockObjJson.Object);
            var result = (OkObjectResult)marketDataController.Index();
            var marketDataVal=(IEnumerable<MarketDataDto>)result.Value;

            Assert.IsTrue(marketDataVal.Count() > 0);
        }

        [TestMethod]
        public void GetAllMarketDataListReturnsCountZero()
        {

            List<MarketData> marketDatas = new();


            List<MarketDataDto> marketDataDtos = new();
           

            Mock<IMarketDataRepository> mockMarketDataRepository = new();

            mockMarketDataRepository.Setup(m => m.GetAllMarketData()).Returns(marketDatas.AsEnumerable());

            Mock<IMapper> mockMapper = new();
            mockMapper.Setup(m => m.Map<IEnumerable<MarketDataDto>>(It.IsAny<IEnumerable<MarketData>>())).Returns(marketDataDtos);
            Mock<IMarketDataBll> mockMarketDataBll = new();
            Mock<IObjectJsonConverter> mockObjJson = new();


            var marketDataController = new MarketDataController(new NullLogger<MarketDataController>(), mockMarketDataRepository.Object, mockMapper.Object, mockMarketDataBll.Object, mockObjJson.Object);
            var result = (OkObjectResult)marketDataController.Index();
            var marketDataVal = (IEnumerable<MarketDataDto>)result.Value;

            Assert.IsTrue(marketDataVal.Count() == 0);
        }

    }
}
