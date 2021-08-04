using DailySharePriceMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Interface
{
    public interface IStockRepository
    {
        DailyStockDetails GetDailyShare(string stockName);
    }
}
