using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsShop.Domain.Concrete;
using SportsShop.Domain.Entities;

namespace SportsShop.DebugConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                for (int i = 0; i < 20; i++)
                {
                    var product = new Product()
                    {
                        Name = $"Product {i}",
                        Description = "Product",
                        Category = "",
                        Price = i
                    };
                    ctx.Products.Add(product);
                }

                //product = ctx.Products.Where(s => s.ProductId == 1).FirstOrDefault();

                ctx.SaveChanges();
            }
        }
    }
}
