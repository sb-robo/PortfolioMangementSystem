using DailySharePriceMS.DBHelper;
using DailySharePriceMS.Interface;
using DailySharePriceMS.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Repository
{
    public class StockRepository : IStockRepository
    {
        private DailyStockPriceContext context;
        private IConfiguration configuration;

        public StockRepository(DailyStockPriceContext _context, IConfiguration _iconfig)
        {
            context = _context;
            configuration = _iconfig;
        }
        public DailyStockDetails GetDailyShare(string stockName)
        {
            bool inMem = configuration.GetValue<bool>("Database:inMem");
            DailyStockDetails stockDetails;
            if (!inMem)
            {
                stockDetails = context.DailyStockPriceDetails.FirstOrDefault(c => c.StockName.ToLower() == stockName.ToLower());
                return stockDetails == null ? null : stockDetails;
            }

            stockDetails = StockDb.dailyStockDetails.FirstOrDefault(c => c.StockName.ToLower() == stockName.ToLower());
            return stockDetails == null ? null : stockDetails;
        }
    }
}
