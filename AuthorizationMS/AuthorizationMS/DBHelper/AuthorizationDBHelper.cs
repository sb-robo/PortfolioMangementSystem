using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMS.Models;

namespace AuthorizationMS.DBHelper
{
    public class AuthorizationDBHelper
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer()
            {
                PortfolioId = 1,
                CustomerName = "Suraj Biswas",
                Username = "suraj@1999",
                Password = "Suraj@123"
            },
            new Customer()
            {
                PortfolioId = 2,
                CustomerName = "Saurav Pandey",
                Username = "Saurav355",
                Password = "saurav@123"
            },
            new Customer()
            {
                PortfolioId = 3,
                CustomerName = "Zafar Khan",
                Username = "zafar@don",
                Password = "zafar@123"
            },
            new Customer()
            {
                PortfolioId = 4,
                CustomerName = "Shrey Agarwal",
                Username = "Shrey@1222",
                Password = "shrey@123"
            }
        };
    }
}
