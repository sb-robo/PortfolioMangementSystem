using PortfolioGateway.Models;
using PortfolioGateway.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioGateway.Context;

namespace PortfolioGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ApplicationDbContext context;
        //private readonly ILoggerManager _logger;
        public PortfolioController(IPortfolioService portfolioService,ApplicationDbContext _context)//ILoggerManager logger
        {
            context = _context;
            //_logger = logger;
            _portfolioService = portfolioService;
        }
      [HttpPost]
      [Route("SellAssets/{id}/{assetType}/{assetName}/{quantity}")]
        public IActionResult SellAssets(int id,string assetType,string assetName, int quantity)
        {
          PortfolioDetails portfolioDetails = _portfolioService.GetCustomerPortfolio(id);
            AssetSaleResponse assetSaleResponse = _portfolioService.SellAsset(portfolioDetails, assetName, assetType,quantity);
            if(assetSaleResponse != null)
            {
                if(assetSaleResponse.SaleStatus == true)
                {                  
                    portfolioDetails.NetWorth = assetSaleResponse.Networth;
                    RemoveAsset(portfolioDetails, assetType, assetName, quantity);
                    portfolioDetails = _portfolioService.GetCustomerPortfolio(id);
                    //_logger.LogInformation($"{assetName} sold from portfolio with portfolioId {portfolioDetails.PortfolioId}");
                    return Ok( portfolioDetails);
                }
            }
            //_logger.LogInformation($"Error while selling assets");
            return BadRequest("Not able to sell assets please check the asset and it's quantity you're trying to sell");
        }
   
        private void RemoveAsset(PortfolioDetails portfolioDetails, string assetType, string assetName,int quantity)
        {
            if(assetType == AssetType.Stock)
            {
                var stock = (from s1 in context.StockDetails
                             where s1.PortfolioId == portfolioDetails.PortfolioId && s1.StockName == assetName
                             select s1).SingleOrDefault();
                stock.StockCount = stock.StockCount - quantity;
                if(stock.StockCount == 0)
                {
                    context.StockDetails.Remove(stock);
                    context.SaveChanges();
                }
                else
                {
                    context.StockDetails.Update(stock);
                    context.SaveChanges();
                }
            }
            else
            {
                var mutualFund = (from s1 in context.MutualFundDetails
                                  where s1.PortfolioId == portfolioDetails.PortfolioId && s1.MutualFundName == assetName
                                  select s1).SingleOrDefault();
                mutualFund.MutualFundUnits = mutualFund.MutualFundUnits - quantity;
                if(mutualFund.MutualFundUnits == 0)
                {
                    context.MutualFundDetails.Remove(mutualFund);
                    context.SaveChanges();
                }
                else
                {
                    context.MutualFundDetails.Update(mutualFund);
                    context.SaveChanges();
                }
            }
        }
        //     [HttpGet]
        //    [Route("id")]
        [HttpGet]
        [Route("id")]
        public PortfolioDetails GetCustomerPortfolio(int portfolioId)
        {
            PortfolioDetails portfolioDetails = _portfolioService.GetCustomerPortfolio(portfolioId);
            //_logger.LogInformation($"retrieving portfolio details of user with portfolioId {portfolioDetails.PortfolioId}");
            return portfolioDetails;
        }
    }
}
