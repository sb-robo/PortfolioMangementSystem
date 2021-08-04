using PortfolioGateway.Models;

namespace PortfolioGateway.Repository
{
    public interface IPortfolioRepository
    {
       PortfolioDetails GetPortfolioById(int id);
    }
}