using Entite;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IServiceCategory serviceCategory;

        public CategoryController(IServiceCategory _serviceaCategory)
        {
            serviceCategory = _serviceaCategory;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await serviceCategory.GetCategory();
        }

        // GET api/<CategoryController>/5
      

        // POST api/<CategoryController>
    

        // PUT api/<CategoryController>/5
    

        // DELETE api/<CategoryController>/5
       
    }
}
