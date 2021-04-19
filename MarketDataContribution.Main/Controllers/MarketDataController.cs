using AutoMapper;
using MarketDataContribution.DataAccess.Model.Repository;
using MarketDataContribution.Main.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public MarketDataController(ILogger<MarketDataController> logger, IMarketDataRepository marketDataRepository,IMapper mapper )
        {
            _logger = logger;
            _marketDataRepository = marketDataRepository;
            _mapper = mapper;
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

    }
}
