using AutoMapper;
using BL;
using DL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL _orderBL;
        IMapper _mapper;
        public OrderController(IOrderBL orderBL ,IMapper mapper)
        {
            _mapper=mapper;
            _orderBL = orderBL;
    
        }
       

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await _orderBL.getOrderAsync(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO != null ? Ok(orderDTO) : BadRequest("not found");
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            Order orderCreated= await _orderBL.addOrderAsync(order);
            if (orderCreated != null)
            {
                OrderDTO orderCreatedDTO = _mapper.Map<Order, OrderDTO>(orderCreated);
                return CreatedAtAction(nameof(Get), new { id = orderCreatedDTO.OrderId }, orderCreatedDTO);
            }
            return BadRequest();
        }
        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]

        //public async Task Put(int id, [FromBody] Order orderToUpdate)
        //{
        //    await _orderBL.Put(id, orderToUpdate);
        //}

    }
}
