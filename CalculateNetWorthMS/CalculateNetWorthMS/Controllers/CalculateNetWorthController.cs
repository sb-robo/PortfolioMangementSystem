﻿using CalculateNetworthMS.Interface;
using CalculateNetworthMS.Models;
using CalculateNetworthMS.Models.Response;
using CalculateNetworthMS.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;

namespace CalculateNetworthMS.Controllers
{
    [Route(ConstRouting.baseRoute)]
    [ApiController]
    public class CalculateNetWorthController : ControllerBase
    {
        private readonly ICalculateNetWorthService _netWorthService;
        private readonly ISellAssetsRepository _sellAssetRepository;

        public CalculateNetWorthController(ICalculateNetWorthService netWorthService, ISellAssetsRepository sellAssetRepository)
        {
            _netWorthService = netWorthService;
            _sellAssetRepository = sellAssetRepository;
        }
        [HttpPost]
        [Route(ConstRouting.getNetWorth)]
        public ActionResult<string> GetNetWorth([FromBody]PortfolioDetails portFolio)
        {
            if (portFolio == null)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return "Portfolio Cannot be Null";
            }

            try
            {
                int netWorth = _netWorthService.CalculateNetWorth(portFolio);
                Response.StatusCode = StatusCodes.Status200OK;
                return Convert.ToString(netWorth);
            }
            catch(Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return "Internal Error";
            }
        }

        [HttpPost]
        [Route(ConstRouting.sellAsset)]
        public ActionResult<AssetSaleResponse> SellAsset([FromBody]PortfolioDetails portfolioDetails)
        {
            try
            {
                AssetSaleResponse assetSaleResponse = _sellAssetRepository.SellAsset(portfolioDetails);

                if (assetSaleResponse.SaleStatus)
                {
                    Response.StatusCode = StatusCodes.Status200OK;
                    return assetSaleResponse;
                }
                else
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                    return assetSaleResponse;
                }
            }
            catch(Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new AssetSaleResponse { SaleStatus = false, Message = "Internal Error", NetWorth = 0 };
            }
        }
    }
}
