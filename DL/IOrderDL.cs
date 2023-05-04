using Entities;

namespace DL
{
    public interface IOrderDL
    {
        Task<Order> Get(int id);
        Task<Order> Post(Order order);
        Task Put(int id, Order orderToUpdate);
    }
}