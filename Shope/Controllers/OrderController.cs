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
        public async Task <ActionResult<Order>>  Get(int id)
        {
            Order order = await service.GetOrderbyId(id);
            OrderDTO orderDTO = Mapper.Map<Order, OrderDTO>(order);
            return Ok(orderDTO); 
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] PostOrderDTO order)
        {

            Order order1 = Mapper.Map<PostOrderDTO, Order>(order);
            Order order2 = await service.AddOrder(order1);

            return Ok(order);



        }

        // PUT api/<OrderController>/5
      
    }
}
