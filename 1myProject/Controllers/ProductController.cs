using AutoMapper;
using BL;
using DL;
using DTO;
using Entities;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IMapper _mapper;
        IProductBL _productBL;
        public ProductController(IProductBL productBL,IMapper mapper)
        {
            _mapper = mapper;
            _productBL = productBL;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromQuery] IEnumerable<int>? categories, [FromQuery] string? nameProduct, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? orderBy = "name", [FromQuery] string? direction = "desc")
        {
            IEnumerable<Product> products = await _productBL.getProductsBySearch(categories, nameProduct, minPrice, maxPrice, orderBy, direction);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO.Count() > 0 ? Ok(productsDTO) : NoContent();
        }
        // GET: api/<ProductController>??
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            Product product = await _productBL.GetProductByIdAsync(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(product);
            return productDTO != null ? Ok(productDTO) : BadRequest("not found");
           
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO newProduct)
        {
            Product product = _mapper.Map<ProductDTO, Product>(newProduct);
            Product addProduct= await _productBL.addProductAsync(product);
            if (addProduct != null)
            {
                ProductDTO addProductDTO = _mapper.Map<Product, ProductDTO>(addProduct);
                return CreatedAtAction(nameof(Get), new { id = addProductDTO.ProductId }, addProductDTO);
            }
            return BadRequest();

        }

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] Product productToUpdate)
        //{
        //    await _productBL.Put(id, productToUpdate);
        //}


    }
}
