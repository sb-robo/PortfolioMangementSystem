using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Routing
{
    public static class ConstRouting
    {
        public const string baseRoute = "api/[controller]";
        public const string getStocknameRoute = "{stockName}";
    }
}
