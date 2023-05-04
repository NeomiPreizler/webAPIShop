using BL;
using DL;
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

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
    
        }
        // GET: api/<OrderController>
        //[HttpGet]
        //public async Task<ActionResult<List<Order>>> Get()
        //{
        //    return await _orderBL.Get();

        //}

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await _orderBL.Get(id);
            return order != null ? Ok(order) : BadRequest("not found");
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
        {
            return await _orderBL.Post(newOrder);

        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Order orderToUpdate)
        {
            await _orderBL.Put(id, orderToUpdate);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
