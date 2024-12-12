using AutoMapper;
using DTO;
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
        IMapper _mapper;

        public CategoryController(IServiceCategory _serviceaCategory,IMapper mapper)
        {
            serviceCategory = _serviceaCategory;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await serviceCategory.GetCategory();
            List<CategoryDTO> categoryDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            if (categoryDTO != null)
            {
                return Ok(categoryDTO);
            }
            else
                return NotFound();
    
        }

        // GET api/<CategoryController>/5
      

        // POST api/<CategoryController>
    

        // PUT api/<CategoryController>/5
    

        // DELETE api/<CategoryController>/5
       
    }
}
