using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketDataContribution.DataAccess.Model
{
    public class MarketDataType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarketDataTypeId { get; set; }
        public string MarketTypeName { get; set; }
        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
