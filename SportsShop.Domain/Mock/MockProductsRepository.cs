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

        public Product DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
