using MarketDataContribution.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.BLL
{
    public interface IMarketDataBll
    {
        void ValidationServiceBasedOnMarketDataType(MarketData marketData);
    }
}
