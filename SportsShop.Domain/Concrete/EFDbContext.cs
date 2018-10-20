namespace SportsShop.Domain.Concrete
{
    using System.Data.Entity;
    using SportsShop.Domain.Entities;

    /*
     * Here is the place where we put all tables definition.
     */
    public class EFDbContext : DbContext
    {
        public DbSet<Identity> Identities { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
