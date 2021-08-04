using DailySharePriceMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.DBHelper
{
    public class StockDb
    {
        public static List<DailyStockDetails> dailyStockDetails { get; set; } = new List<DailyStockDetails>()
        {
            new DailyStockDetails()
            {
                StockId = 1,
                StockName = "HDFC",
                StockValue=100
            },
            new DailyStockDetails()
            {
                StockId = 2,
                StockName = "Asian Paints",
                StockValue = 2000
            },
            new DailyStockDetails()
            {
                StockId = 3,
                StockName = "AXIS",
                StockValue = 800
            },
            new DailyStockDetails()
            {
                StockId = 4,
                StockName = "Bajaj Automobiles",
                StockValue = 3000
            },
            new DailyStockDetails()
            {
                StockId = 5,
                StockName = "ICICI",
                StockValue = 400
            },
            new DailyStockDetails()
            {
                StockId = 6,
                StockName = "INFOSYS",
                StockValue = 1400
            },
            new DailyStockDetails()
            {
                StockId = 7,
                StockName = "Wipro",
                StockValue = 450
            },

            new DailyStockDetails()
            {
                StockId = 9,
                StockName = "Lupin",
                StockValue = 400
            },
            new DailyStockDetails()
            {
                StockId = 10,
                StockName = "ITC",
                StockValue = 200
            },
            new DailyStockDetails()
            {
                StockId = 11,
                StockName = "BajajFinance",
                StockValue = 5000
            },
            new DailyStockDetails()
            {
                StockId = 12,
                StockName = "JSWSteel",
                StockValue = 700
            },
            new DailyStockDetails()
            {
                StockId = 13,
                StockName = "HCL",
                StockValue = 1000
            },
            new DailyStockDetails()
            {
                StockId = 14,
                StockName = "NestleIndia",
                StockValue = 20000
            },
            new DailyStockDetails()
            {
                StockId = 15,
                StockName = "SBI",
                StockValue = 450
            },
            new DailyStockDetails()
            {
                StockId = 16,
                StockName = "Tata Motors",
                StockValue = 350
            },
            new DailyStockDetails()
            {
                StockId = 17,
                StockName = "HDFC Insurance",
                StockValue = 650
            }
        };
    }
}
