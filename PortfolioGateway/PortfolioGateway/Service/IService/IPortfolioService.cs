using PortfolioGateway.Models;

namespace PortfolioGateway.Service
{
    public interface IPortfolioService
    {
        int CalculateNetWorth(PortfolioDetails portfolioDetails);
        PortfolioDetails GetCustomerPortfolio(int portfolioId);
        AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails, string assetName, string assetType,int quantity);
    }
}