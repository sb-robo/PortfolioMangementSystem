using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Models
{
    public class DailyStockDetails
    {
        [Key]
        public int StockId { get; set; }
        [StringLength(30)]
        public string StockName { get; set; }
        [MaxLength(5)]
        public int StockValue { get; set; }
    }
}
