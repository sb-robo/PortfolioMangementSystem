using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMS.Models
{
    public class AuthorizationContext: DbContext
    {
        public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
        {

        }
        public DbSet<Customer> Authorization_Details { get; set; }
    }
}
