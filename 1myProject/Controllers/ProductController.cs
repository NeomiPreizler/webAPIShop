using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        
        IProductBL _productBL;
        public ProductController(IProductBL productBL)
        {

            _productBL = productBL;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get([FromQuery] IEnumerable<string>? categories, [FromQuery] string? nameProduct, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? orderBy = "name", [FromQuery] string? direction = "desc")
        {
            IEnumerable<Product> products = await _productBL.Get(categories, nameProduct, minPrice, maxPrice, orderBy, direction);
            return products.Count() > 0 ? Ok(products) : NoContent();
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product newProduct)
        {
            return await _productBL.Post(newProduct);
            
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Product productToUpdate)
        {
            await _productBL.Put(id, productToUpdate);
        }

        
    }
}
