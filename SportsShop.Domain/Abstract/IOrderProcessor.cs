namespace SportsShop.Domain.Abstract
{
    using SportsShop.Domain.Entities;

    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
