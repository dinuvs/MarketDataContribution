using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.Model
{
    public class MarketData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarketDataId { get; set; }
        public int FxCurrencyPairId { get; set; }
        public int MarketDataTypeId { get; set; }
        [Column(TypeName = "decimal(14,6)")]
        public decimal Bid { get; set; }
        [Column(TypeName = "decimal(14,6)")]
        public decimal Ask { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdated { get; set; }

        [ForeignKey("FxCurrencyPairId")]
        public FxCurrencyPair FxCurrencyPair { get; set; }
        [ForeignKey("MarketDataTypeId")]
        public MarketDataType MarketDataType { get; set; }
    }
}
