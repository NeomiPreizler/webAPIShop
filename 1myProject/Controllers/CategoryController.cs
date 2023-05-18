using AutoMapper;
using DTO;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using DL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryBL _categoryBL;
        IMapper _mapper;
        public CategoryController(ICategoryBL categoryBL, IMapper mapper)
        {
             _categoryBL = categoryBL;
              _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<Category> categories = await _categoryBL.GetAllCategoriesAsync();
            if (categories != null)
            {
                List<CategoryDTO> categoriesDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
                return Ok(categoriesDTO);
            }
            return BadRequest("No categories");

        }


        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            Category categoryCreated = await _categoryBL.AddCategoryAsync(category);
            if (categoryCreated != null)
            {
                CategoryDTO categoryDTOCreated = _mapper.Map<Category, CategoryDTO>(categoryCreated);
                return CreatedAtAction(nameof(Get), new { id = categoryDTOCreated.CategoryId }, categoryDTOCreated);
            }
            return BadRequest();
            

        }


    }
}
