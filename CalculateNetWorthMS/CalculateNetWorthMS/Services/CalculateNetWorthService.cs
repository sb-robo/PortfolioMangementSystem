using System;
using System.Linq;
using System.Net.Http;
using CalculateNetworthMS.Interface;
using CalculateNetworthMS.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CalculateNetworthMS.Services
{
    public class CalculateNetWorthService: ICalculateNetWorthService
    {
        private IConfiguration configuration;
        public CalculateNetWorthService(IConfiguration iconfig)
        {
            configuration = iconfig;
        }

        public int CalculateNetWorth(PortfolioDetails portFolio)
        {
        
            int netWorth = 0;
            string urldsp = configuration.GetValue<string>("MyUrls:URLDSP");
            string urldnp = configuration.GetValue<string>("MyUrls:URLDNP");

            using var client = new HttpClient();

            try
            {
                foreach (var stock in portFolio.StockList)
                {
                    int quantity = portFolio.StockList.FirstOrDefault(x => x.StockName == stock.StockName).StockCount;
                    string stockName = stock.StockName;
                    string uri = $"{urldsp}/{stockName}";

                    var response = client.GetAsync(uri).Result;
                    if (response != null)
                    {
                        DailyStockDetails stockDetails = JsonConvert.DeserializeObject<DailyStockDetails>(response.Content.ReadAsStringAsync().Result);
                        int price = quantity * stockDetails.StockValue;
                        netWorth += price;
                    }
                }

                foreach (var mutualFund in portFolio.MutualFundList)
                {
                    int quantity = portFolio.MutualFundList.FirstOrDefault(x => x.MutualFundName == mutualFund.MutualFundName).MutualFundUnits;
                    var mutualFundName = mutualFund.MutualFundName;
                    string uri = $"{urldnp}/{mutualFundName}";
                    var response = client.GetAsync(uri).Result;
                    if (response != null)
                    {
                        DailyMutualFundDetails mutualFundDetails = JsonConvert.DeserializeObject<DailyMutualFundDetails>(response.Content.ReadAsStringAsync().Result);

                        int price = quantity * mutualFundDetails.Nav;
                        netWorth += price;
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return netWorth;
        }
    }
}
