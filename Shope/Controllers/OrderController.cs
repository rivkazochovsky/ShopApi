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
        public OrderController(IServiceOrder _serviceOrder)
        {
            service = _serviceOrder;
        }
        // GET: api/<OrderController>
     
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {

            Order neworder = await service.AddOrder(order);
                if (order != null)
                    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, neworder);
                else
                    return BadRequest();

            

        }

        // PUT api/<OrderController>/5
      
    }
}
