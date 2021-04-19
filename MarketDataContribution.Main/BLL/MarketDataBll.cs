using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.ValidationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.BLL
{
    enum MarketDataTypes
    {
        FxQuote = 3,
        LegalAudting = 4
        // Add more DataTypes here 

    }
    public class MarketDataBll: IMarketDataBll
    {
        private readonly IMarketDataValidationService _marketDataValidationService;

        public MarketDataBll(IMarketDataValidationService marketDataValidationService)
        {
            _marketDataValidationService = marketDataValidationService;
        }
        public void ValidationServiceBasedOnMarketDataType(MarketData marketData)
        {
           
            switch ((MarketDataTypes)marketData.MarketDataTypeId)
            {
                case MarketDataTypes.FxQuote:
                    if(!_marketDataValidationService.ValidateFxBidAndAsk(marketData))
                    {
                        marketData.Error = "FxQuote : Bid or Ask has negative values";
                    }
                    break;
                case MarketDataTypes.LegalAudting:
                    if(!_marketDataValidationService.ValidateLegalAuditing(marketData))
                    {
                        marketData.Error = "LegalAuditing: Validation Failure";
                    }
                    break;

                    //Add More Market Data Type Validations here
                default:
                    break;

            }
        }
    }
}
