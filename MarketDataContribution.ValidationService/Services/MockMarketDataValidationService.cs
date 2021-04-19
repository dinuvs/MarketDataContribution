using MarketDataContribution.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.ValidationService.Services
{
    public class MockMarketDataValidationService : IMarketDataValidationService
    {

        public bool ValidateFxBidAndAsk(MarketData marketData)
        {
            if(ValidateFxQuotesValue(marketData.Bid) && ValidateFxQuotesValue(marketData.Ask))
            {
                return true;
            }
            return false;

        }

        private bool ValidateFxQuotesValue(decimal value)
        {
            if(value <0.0M)
            {
                return false;
            }
            return true;
        }

        public bool ValidateLegalAuditing(MarketData marketData)
        {
            //Implement Legal Auditing validation logic here 

            return false;

        }

    }
}
