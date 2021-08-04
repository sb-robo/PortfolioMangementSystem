using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworthMS.Models.Response
{
    public class AssetSaleResponse
    {
        public bool SaleStatus { get; set; }
        public string Message { get; set; }
        public int NetWorth { get; set; }
    }
}
