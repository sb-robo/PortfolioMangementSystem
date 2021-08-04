using CalculateNetworthMS.Models;
using System.Linq;
using CalculateNetworthMS.Interface;
using CalculateNetworthMS.Models.Response;

namespace CalculateNetworthMS.Repository
{
    public class SellAssetsRepository : ISellAssetsRepository
    {
        private readonly ICalculateNetWorthService _netWorthService;

        public SellAssetsRepository(ICalculateNetWorthService netWorthService)
        {
            _netWorthService = netWorthService;
        }

        public AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails)
        {

            AssetSaleResponse assetSaleResponse = null;

            bool saleStatus = false;

            if(portfolioDetails.AssetTypeToBeSold == "Stock")
            {
                StockDetails stockToBeSold =  portfolioDetails.StockList.FirstOrDefault(x => x.StockName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());
                saleStatus = portfolioDetails.StockList.Remove(stockToBeSold);
                stockToBeSold.StockCount = stockToBeSold.StockCount - portfolioDetails.AssetQuantityToBeSold;
                portfolioDetails.StockList.Add(stockToBeSold);

            }
            else if(portfolioDetails.AssetTypeToBeSold == "MutualFund")
            {
                MutualFundDetails mutualFundToBeSold = portfolioDetails.MutualFundList.FirstOrDefault(x => x.MutualFundName.ToLower() == portfolioDetails.AssetNameToBeSold.ToLower());
                saleStatus = portfolioDetails.MutualFundList.Remove(mutualFundToBeSold);
                mutualFundToBeSold.MutualFundUnits = mutualFundToBeSold.MutualFundUnits - portfolioDetails.AssetQuantityToBeSold;
                portfolioDetails.MutualFundList.Add(mutualFundToBeSold);
                
            }

            if(saleStatus)
            {
                assetSaleResponse = new AssetSaleResponse()
                {
                    SaleStatus = saleStatus,
                    Message = "Asset Sold Successfully",
                    NetWorth = _netWorthService.CalculateNetWorth(portfolioDetails)
                };
            }
            else
            {
                assetSaleResponse = new AssetSaleResponse()
                {
                    SaleStatus = saleStatus,
                    Message = "Invalid AssetType",
                    NetWorth = 0
                };
            }

            return assetSaleResponse;
        }
    }
}
