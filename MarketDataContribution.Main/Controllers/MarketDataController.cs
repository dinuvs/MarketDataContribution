using AutoMapper;
using MarketDataContribution.DataAccess.Model.Repository;
using MarketDataContribution.Main.BLL;
using MarketDataContribution.Main.Dtos;
using MarketDataContribution.Main.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Controllers
{
    [ApiController]
    [Route("api/MarketData")]
    public class MarketDataController:ControllerBase
    {
        private readonly ILogger<MarketDataController> _logger;
        private readonly IMarketDataRepository _marketDataRepository;
        private readonly IMapper _mapper;
        private readonly IMarketDataBll _marketDataBll;
        private readonly IObjectJsonConverter _objectJsonConverter;

        public MarketDataController(ILogger<MarketDataController> logger, IMarketDataRepository marketDataRepository,
            IMapper mapper, IMarketDataBll marketDataBll, IObjectJsonConverter objectJsonConverter )
        {
            _logger = logger;
            _marketDataRepository = marketDataRepository;
            _mapper = mapper;
            _marketDataBll = marketDataBll;
            _objectJsonConverter = objectJsonConverter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var marketDatas = _marketDataRepository.GetAllMarketData();
            if (marketDatas != null)
            {
                _logger.LogInformation($"Success:MarketData fetched successfully");
                return Ok(_mapper.Map<IEnumerable<MarketDataDto>>(marketDatas));
            }
            _logger.LogInformation($"Error:Error Fetching Market Data");
            return NotFound();
        }

        /// <summary>
        /// Add a Debit or Credit Transaction
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///   { FxCurrencyPairId:1, MarketDataTypeId:3, Bid:1.123, Ask:1.133, LastUpdatedBy:"System" }
        /// </remarks>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string request)
        {
            var marketData = _objectJsonConverter.ConvertTransactionJsonDataToObj(request);

            if(marketData != null)
            {

                _marketDataBll.ValidationServiceBasedOnMarketDataType(marketData);
                //if validation has failed error will be logged in the marketdata.error field
                if (!string.IsNullOrEmpty(marketData.Error))
                {
                    _logger.LogInformation($"Error: Validation Failed: {marketData.Error}");
                    return Content($"Error: Validation Failed: {marketData.Error}");
                }
                var marketDataAdded = await _marketDataRepository.AddAsync(marketData);
                if(marketDataAdded != null)
                {
                    _logger.LogInformation($"Info:Market Data with MarketDataType: {marketDataAdded.MarketDataTypeId} created successfully");
                    return Ok(_mapper.Map<MarketDataDto>(marketDataAdded));
                }
            }
            return Content("Market Data list is empty");

        }

    }
}
