using Entities;

namespace BL
{
    public interface IOrderBL
    {
        Task<Order> GetOrderAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task UpdateOrderAsync(int id, Order orderToUpdate);
  
    }
}