using CalculateNetworthMS.Models;
using CalculateNetworthMS.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworthMS.Interface
{
    public interface ISellAssetsRepository
    {
        AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails);
    }
}
