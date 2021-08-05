using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioGateway.Routing
{
    public class ConstRouting
    {
        public const string baseRoute = "api/[controller]";
        public const string sellAssetRoute = "SellAssets/{id}/{assetType}/{assetName}/{quantity}";
        public const string getPortfolioRoute = "{portfolioId}";
    }
}