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
    public class OrderController : ControllerBase
    {
        IServiceOrder service;
        IMapper Mapper;
        public OrderController(IServiceOrder _serviceOrder,IMapper _mapper)
        {
            service = _serviceOrder;
            Mapper = _mapper;
        }
        // GET: api/<OrderController>
     
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<OrderDTO>>  Get(int id)
        {
            Order order = await service.GetOrderbyId(id);
            if (order != null)
                return Ok(Mapper.Map<Order, OrderDTO>(order));
            return NotFound();
        }
        /// <summary>
        
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] PostOrderDTO order)
        {

            Order newOrder = await service.AddOrder(Mapper.Map<PostOrderDTO, Order>(order));
            if (newOrder != null)
                return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, Mapper.Map<Order, OrderDTO>(newOrder));
            return BadRequest();



        }

        // PUT api/<OrderController>/5
      
    }
}
