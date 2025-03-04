using AutoMapper;
using DTO;
using Entite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        IMemoryCache memoryCache;

        public CategoryController(IServiceCategory _serviceaCategory,IMapper mapper,IMemoryCache _memoryCache)
        {
            serviceCategory = _serviceaCategory;
            _mapper = mapper;
            memoryCache = _memoryCache; 
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            if (!memoryCache.TryGetValue("categories", out List<Category> categories))
            {
                categories = await serviceCategory.GetCategory();
                memoryCache.Set("categories", categories, TimeSpan.FromMinutes(30));
            }
            List<CategoryDTO> categoryDTOList = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return categoryDTOList != null ? Ok(categoryDTOList) : BadRequest();
        }

        // GET api/<CategoryController>/5


        // POST api/<CategoryController>


        // PUT api/<CategoryController>/5


        // DELETE api/<CategoryController>/5

    }
}
