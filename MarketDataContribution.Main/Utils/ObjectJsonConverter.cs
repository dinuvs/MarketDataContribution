using MarketDataContribution.DataAccess.Model;
using MarketDataContribution.Main.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Utils
{
    public class ObjectJsonConverter : IObjectJsonConverter
    {
        public MarketData ConvertTransactionJsonDataToObj(string jsonData)
        {
            return JsonConvert.DeserializeObject<MarketData>(jsonData);
        }
    }
}
