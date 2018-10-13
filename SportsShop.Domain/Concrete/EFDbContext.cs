using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsShop.Domain.Entities;

namespace SportsShop.Domain.Concrete
{
    /*
     * Here is the place where we put all tables definition.
     */
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Identity> Identities { get; set; }
    }
}
