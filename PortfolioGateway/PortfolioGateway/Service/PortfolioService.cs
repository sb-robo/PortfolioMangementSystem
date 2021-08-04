using PortfolioGateway.Models;
using PortfolioGateway.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PortfolioGateway.Context;

namespace PortfolioGateway.Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private ApplicationDbContext context;
        public PortfolioService(IPortfolioRepository portfolioRepository, ApplicationDbContext _context)
        {
            _portfolioRepository = portfolioRepository;
            context = _context;
            
        }

        public PortfolioDetails GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = _portfolioRepository.GetPortfolioById(portfolioId);
            portfolioDetails.NetWorth = CalculateNetWorth(portfolioDetails);
            return portfolioDetails;
        }
        
        public int CalculateNetWorth(PortfolioDetails portfolioDetails)
        {
            string uri = "http://localhost:63015/api/CalculateNetWorth/netWorth";
            var jsonData = JsonConvert.SerializeObject(portfolioDetails);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(uri, encodedData).Result;
            if (response != null)
            {
                int netWorth = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);
                return netWorth;
            }
            return 0;
        }


        public AssetSaleResponse SellAsset(PortfolioDetails portfolioDetails, string assetName, string assetType,int assetQuantity)
        {
            portfolioDetails.AssetNameToBeSold = assetName;
            portfolioDetails.AssetTypeToBeSold = assetType;
            portfolioDetails.AssetQuantityToBeSold = assetQuantity;
            var jsonData = JsonConvert.SerializeObject(portfolioDetails);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            string uri = "http://localhost:63015/api/CalculateNetWorth/sellAsset";
            using var client = new HttpClient();
            var response = client.PostAsync(uri, encodedData).Result;
            if (response != null)
            {
                AssetSaleResponse assetSaleResponse = JsonConvert.DeserializeObject<AssetSaleResponse>(response.Content.ReadAsStringAsync().Result);
                return assetSaleResponse;
            }
            return null;
        }
    }
}
