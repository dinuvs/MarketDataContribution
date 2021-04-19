using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketDataContribution.Main.Dtos
{
    public class MarketDataDto
    {
        public int FxCurrencyPairId { get; set; }
        public int MarketDataTypeId { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
