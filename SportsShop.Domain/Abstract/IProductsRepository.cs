namespace SportsShop.Domain.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SportsShop.Domain.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
