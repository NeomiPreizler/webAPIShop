using Entities;

namespace BL
{
    public interface IOrderBL
    {
        Task<Order> getOrderAsync(int id);
        Task<Order> addOrderAsync(Order order);
        //Task Put(int id, Order orderToUpdate);
  
    }
}