using Entities;

namespace DL
{
    public interface IOrderDL
    {
        Task<Order> getOrderAsync(int id);
        Task<Order> addOrderAsync(Order order);
        Task Put(int id, Order orderToUpdate);
    }
}