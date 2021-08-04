using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Models
{
    public class DailyStockPriceContext: DbContext
    {
        public DailyStockPriceContext(DbContextOptions<DailyStockPriceContext> options) : base(options)
        {

        }
        public DbSet<DailyStockDetails> DailyStockPriceDetails { get; set; }
    }
}
