namespace SportsShop.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SportsShop.Domain.Abstract;
    using SportsShop.Domain.Entities;

    public class EFProductsRepository : IProductsRepository
    {
        public EFDbContext _dbContext { get; set; }

        public IEnumerable<Product> Products
        {
            get
            {
                return _dbContext.Products;
            }
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = _dbContext.Products.Find(productId);

            if (dbEntry != null)
            {
                _dbContext.Products.Remove(dbEntry);
                _dbContext.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = _dbContext.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
