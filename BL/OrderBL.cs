using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  
        public class OrderBL:IOrderBL
        {
            IOrderDL _orderDL;
            public OrderBL(IOrderDL orderDL)
            {
                _orderDL = orderDL;
            }

            public async Task<Order> Get(int id)
            {
                return await _orderDL.Get(id);
            }

            public async Task<Order> Post(Order order)
            {
                return await _orderDL.Post(order);
            }

            public async Task Put(int id, Order orderToUpdate)
            {
                _orderDL.Put(id, orderToUpdate);
            }

          
        //public void Delete(int id)
        //{



        //}
    }
    }
