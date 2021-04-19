using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.Main.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Utils
{
    public interface IObjectJsonConverter
    {
        MarketData ConvertTransactionJsonDataToObj(string jsonData);
    }
}
