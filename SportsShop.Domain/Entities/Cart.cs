namespace SportsShop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cart
    {
        private List<CartLine> LineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity = 1)
        {
            CartLine line = LineCollection
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if(line ==null)
            {
                //Add new
                LineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                //update quantity
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public void Clear()
        {
            LineCollection.Clear();
        }

        public decimal TotalValue
        {
            get { return LineCollection.Sum(p => p.Product.Price * p.Quantity); }
        }

        public IEnumerable<CartLine> Lines
        {
            get { return LineCollection; }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
