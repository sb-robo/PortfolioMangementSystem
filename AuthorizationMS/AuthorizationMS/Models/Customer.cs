using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Added
using System.ComponentModel.DataAnnotations;

namespace AuthorizationMS.Models
{
    public class Customer
    {
        [Key]
        public int PortfolioId { get; set; }

        [StringLength(30,MinimumLength = 3)]
        public string CustomerName { get; set; }

        [StringLength(30, MinimumLength = 6)]
        public string Username { get; set; }

        [StringLength(18, MinimumLength = 6)]
        public string Password { get; set; }
        public string token { get; set; }
    }
}
