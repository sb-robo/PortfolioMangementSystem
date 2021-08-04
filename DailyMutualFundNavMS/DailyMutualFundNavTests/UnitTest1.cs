using DailyMutualFundNavMS.Controllers;
using DailyMutualFundNavMS.Interface;
using DailyMutualFundNavMS.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DailyMutualFundNavTests
{
    public class Tests
    {
        List<DailyNavDetails> mutualFunds = new List<DailyNavDetails>();
        private readonly DailyNavController dailyNavController;
        private readonly Mock<ILoggerManager> mockLogger = new Mock<ILoggerManager>();
        private readonly Mock<IMutualFundRepo> mockRepository = new Mock<IMutualFundRepo>();
        public Tests()
        {
            dailyNavController = new DailyNavController(mockRepository.Object, mockLogger.Object);
        }




        [SetUp]
        public void Setup()
        {

            mutualFunds = new List<DailyNavDetails>()
            {
                new DailyNavDetails{ MutualFundId=1, MutualFundName="ABC", Nav=1},
                new DailyNavDetails{ MutualFundId=2, MutualFundName="APP", Nav=2}
            };
            mockRepository.Setup(x => x.GetDailyNav(It.IsAny<string>())).Returns((string s) => mutualFunds.FirstOrDefault(x => x.MutualFundName.Equals(s)));

        }

        [Test]
        public void GetDailyNavDetail_ValidStockName_returns_Ok()
        {
            var mutualFund = dailyNavController.GetMutualFundDetail("ABC");
            ObjectResult result = mutualFund as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_BadRequest()
        {
            var mutualFund = dailyNavController.GetMutualFundDetail("");
            Assert.IsInstanceOf<BadRequestResult>(mutualFund);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_NoContent()
        {
            var mutualFund = dailyNavController.GetMutualFundDetail("BitCoin");
            Assert.IsInstanceOf<NoContentResult>(mutualFund);
        }

    }
}