using MarketDataContribution.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.ValidationService.Services
{
    public interface IMarketDataValidationService
    {
        bool ValidateFxBidAndAsk(MarketData marketData);

        bool ValidateLegalAuditing(MarketData marketData);
    }
}
