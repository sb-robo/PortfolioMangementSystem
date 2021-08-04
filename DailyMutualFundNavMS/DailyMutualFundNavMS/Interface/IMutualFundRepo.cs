using DailyMutualFundNavMS.Models;

namespace DailyMutualFundNavMS.Interface
{
    public interface IMutualFundRepo
    {
        DailyNavDetails GetDailyNav(string MutualFundName);
    }
}
