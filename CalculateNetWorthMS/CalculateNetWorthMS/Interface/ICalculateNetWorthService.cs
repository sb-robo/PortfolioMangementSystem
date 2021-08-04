using CalculateNetworthMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateNetworthMS.Interface
{
    public interface ICalculateNetWorthService
    {
        int CalculateNetWorth(PortfolioDetails portFolio);
    }
}
