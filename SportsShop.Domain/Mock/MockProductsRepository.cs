namespace SportsShop.Domain.Mock
{
    using System.Collections.Generic;
    using SportsShop.Domain.Abstract;
    using SportsShop.Domain.Entities;

    public class MockProductsRepository : IProductsRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product { Name = "Football", Price = 25 },
                    new Product { Name = "Baseball", Price = 9 },
                    new Product { Name = "Running Shoes", Price = 179 }
                };
            }
        }
    }
}
