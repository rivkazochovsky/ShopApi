using AutoMapper;
using DTO;
using Entite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IServiceProduct service;
        IMapper _Mapper;
        public ProductController(IServiceProduct _serviceProduct,IMapper mapper)
        {
            service = _serviceProduct;
            _Mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds, [FromQuery] string? desc)

        {
            List<Product> Products = await service.GetProducts(minPrice, maxPrice, categoryIds, desc);
            List<ProductDTO> productsDTO = _Mapper.Map<List<Product>, List<ProductDTO>>(Products);
            return Ok(productsDTO);
        }

        //GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)

        {
          
            Product product1 = await service.GetProductbyId(id);

          return _Mapper.Map<Product, ProductDTO>(product1);
            
        }

        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task<ActionResult<Product>> Post([FromBody] Product product)
        //{
        //    Product newProduct = await service.AddProduct(product);
        //    if (newProduct != null)
        //        return CreatedAtAction(nameof(Get), new { id = product.ProductId }, newProduct);
        //    else
        //        return BadRequest();

        //}


    }
}
