using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDL:IOrderDL
    {
        MyShopDbContext _myShopDbContext;

        public OrderDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }

        public async Task<List<Order>> Get(int id)
        {

            return await _myShopDbContext.Orders.ToListAsync();
        }

        public async Task<Order> Post(Order order)
        {
            await _myShopDbContext.Orders.AddAsync(order);
            await _myShopDbContext.SaveChangesAsync();
            return order;

        }

        public async Task Put(int id, Order orderToUpdate)
        {

            Order order = await _myShopDbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _myShopDbContext.Orders.Update(orderToUpdate);

                await _myShopDbContext.SaveChangesAsync();
            }

        }


    }
}
