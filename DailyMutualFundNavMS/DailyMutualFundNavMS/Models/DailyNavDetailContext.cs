using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyMutualFundNavMS.Models
{
    public class DailyNavDetailContext: DbContext
    {
        public DailyNavDetailContext(DbContextOptions<DailyNavDetailContext> options) : base(options)
        {

        }
        public DbSet<DailyNavDetails> DailyNavPriceDetails { get; set; }
    }
}
