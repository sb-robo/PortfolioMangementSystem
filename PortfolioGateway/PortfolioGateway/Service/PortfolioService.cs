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
using Microsoft.Extensions.Configuration;

namespace PortfolioGateway.Service
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private ApplicationDbContext context;
        private IConfiguration configuration;
        public PortfolioService(IPortfolioRepository portfolioRepository, ApplicationDbContext _context, IConfiguration _iconfig)
        {
            _portfolioRepository = portfolioRepository;
            context = _context;
            configuration = _iconfig;
        }

        public PortfolioDetails GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = _portfolioRepository.GetPortfolioById(portfolioId);
            portfolioDetails.NetWorth = CalculateNetWorth(portfolioDetails);
            return portfolioDetails;
        }
        
        public int CalculateNetWorth(PortfolioDetails portfolioDetails)
        {
            string uri = configuration.GetValue<string>("MyUrls:URLNetWorth");
            var jsonData = JsonConvert.SerializeObject(portfolioDetails);
            var encodedData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = client.PostAsync(uri, encodedData).Result;
            if (response != null)
            {
                AssetSaleResponse assetSaleResponse = JsonConvert.DeserializeObject<AssetSaleResponse>(response.Content.ReadAsStringAsync().Result);
                return assetSaleResponse.Networth;
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
            string uri = configuration.GetValue<string>("MyUrls:URLSellAsset");
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
