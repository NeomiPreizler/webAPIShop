﻿using DL;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{

    public class OrderBL : IOrderBL
    {
        ILogger<OrderBL> _logger;
        IOrderDL _orderDL;
        IProductDL _productDL;

        public OrderBL(IOrderDL orderDL, ILogger<OrderBL> logger, IProductDL productDL)
        {
            _orderDL = orderDL;
            _logger = logger;
            _productDL = productDL;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _orderDL.GetOrderAsync(id);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            int chekSum = 0;

            foreach (OrderItem orderItem in order.OrderItems)
            {
                Product productChekSum = await _productDL.GetProductByIdAsync(orderItem.ProductId);
                chekSum += productChekSum.Price;
            }

            if (order.OrderSum != chekSum)
            {
                order.OrderSum = chekSum;
                _logger.LogDebug("this user changed is sum", order.UserId);
            }
            return await _orderDL.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, Order orderToUpdate)
        {
            _orderDL.UpdateOrderAsync(id, orderToUpdate);
        }

    }
}
