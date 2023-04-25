using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBL _categoryBL;
        public CategoryController(ICategoryBL categoryBL)
        {
             _categoryBL = categoryBL;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await _categoryBL.Get();

        }



        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category newProduct)
        {
            return await _categoryBL.Post(newProduct);

        }


    }
}
