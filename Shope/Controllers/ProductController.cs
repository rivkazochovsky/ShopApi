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
        public ProductController(IServiceProduct _serviceProduct)
        {
            service = _serviceProduct;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await service.GetProducts();
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public async Task <ActionResult<Product>> Get(int id)
        //{
        //    return await service.GetProductbyId(id);
        //}

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
