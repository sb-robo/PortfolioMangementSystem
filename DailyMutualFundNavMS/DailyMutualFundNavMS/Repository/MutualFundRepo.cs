using DailyMutualFundNavMS.InMemDB;
using DailyMutualFundNavMS.Interface;
using DailyMutualFundNavMS.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DailyMutualFundNavMS.Repository
{
    public class MutualFundRepo : IMutualFundRepo
    {
        private DailyNavDetailContext context;
        private IConfiguration configuration;

        public MutualFundRepo(DailyNavDetailContext _context, IConfiguration _iconfig)
        {
            context = _context;
            configuration = _iconfig;
        }
        public DailyNavDetails GetDailyNav(string mutualFundName)
        {
            bool inMem = configuration.GetValue<bool>("Database:inMem");
            DailyNavDetails mutualfundDetails;
            if (!inMem)
            {
             mutualfundDetails = context.DailyNavPriceDetails.FirstOrDefault(c => c.MutualFundName.ToLower() == mutualFundName.ToLower());
                return mutualfundDetails == null ? null : mutualfundDetails;
            }
            mutualfundDetails = Database.dailyNavDetails.FirstOrDefault(c => c.MutualFundName.ToLower() == mutualFundName.ToLower());
            return mutualfundDetails == null ? null : mutualfundDetails;

        }

    }
}
