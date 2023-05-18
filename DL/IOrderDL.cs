using Entities;

namespace DL
{
    public interface IOrderDL
    {
        Task<Order> GetOrderAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task UpdateOrderAsync(int id, Order orderToUpdate);
    }
}