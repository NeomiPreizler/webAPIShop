using Entities;

namespace BL
{
    public interface IOrderBL
    {
        Task<Order> Get(int id);
        Task<Order> Post(Order order);
        Task Put(int id, Order orderToUpdate);
        //Task Delete(int id);
    }
}