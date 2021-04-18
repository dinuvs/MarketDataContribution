using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataContribution.DataAccess.Model
{
    public class FxCurrencyPair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FxCurrencyPairId { get; set; }

        public string FxCurrencyPairName { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
