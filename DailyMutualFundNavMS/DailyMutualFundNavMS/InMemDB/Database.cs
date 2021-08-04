using DailyMutualFundNavMS.Models;
using System.Collections.Generic;

namespace DailyMutualFundNavMS.InMemDB
{
    public class Database
    {

        public static List<DailyNavDetails> dailyNavDetails { get; set; } = new List<DailyNavDetails>() {
        new DailyNavDetails()
            {
                MutualFundId = 1,
                MutualFundName = "Quant Small Cap Fund Direct Plan-Growth",
                Nav= 126
            }, 
        new DailyNavDetails()
            {
                MutualFundId = 2,
                MutualFundName = "Axis Small Cap Fund Direct-Growth",
                Nav= 60
            },
        new DailyNavDetails()
            {
                MutualFundId = 3,
                MutualFundName = "Kotak Small Cap Fund Direct-Growth",
                Nav= 163
            },
        new DailyNavDetails()
            {
                MutualFundId = 4,
                MutualFundName = "ICICI Small Cap Fund  Direct-Growth",
                Nav= 50
            },
        new DailyNavDetails()
            {
                MutualFundId = 5,
                MutualFundName = "Quant Mid Cap Fund Direct-Growth",
                Nav= 112
            },
        new DailyNavDetails()
            {
                MutualFundId = 6,
                MutualFundName = "BNP Paribas MidCap Direct-Growth",
                Nav= 61
            },
        new DailyNavDetails()
            {
                MutualFundId = 7,
                MutualFundName = "Tata MidCap Direct Plan-Growth",
                Nav= 242
            },
        new DailyNavDetails()
            {
                MutualFundId = 8,
                MutualFundName = "Edelweiss Mid Cap Direct Plan-Growth",
                Nav= 51
            },
        new DailyNavDetails()
            {
                MutualFundId = 9,
                MutualFundName = "SBI Large Cap Fund Direct Plan-Growth",
                Nav= 351
            },
        new DailyNavDetails()
            {
                MutualFundId = 10,
                MutualFundName = "HDFC Small Cap Fund Direct-Growth",
                Nav= 75
            },
        new DailyNavDetails()
            {
                MutualFundId =11,
                MutualFundName = "Tata Large Cap Fund Direct Plan-Growth",
                Nav= 331
            },
        new DailyNavDetails()
            {
                MutualFundId = 12,
                MutualFundName = "Nippon India Value Direct-Growth",
                Nav= 120
            }
        };
    }
}
