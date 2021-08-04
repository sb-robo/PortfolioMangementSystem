using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNavMS.Models
{
    public class DailyNavDetails
    {
        [Key]
        public int MutualFundId { get; set; }
        [StringLength(50)]
        public string MutualFundName { get; set; }
        [MaxLength(5)]
        public int Nav { get; set; }
    }
}
