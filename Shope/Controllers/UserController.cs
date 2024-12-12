using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entite;
using Service;
using System.Threading.Tasks;


using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IServiceUser service ;
        IMapper _Mapper;
        public UserController(IServiceUser _serviceUser,IMapper mapper)
        {
            service = _serviceUser;
            _Mapper = mapper;
        }
        
        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<UserController>/5
        [HttpGet("{id}")]
        public  async Task<ActionResult<UserDTO>> Get(int id)
        {

            User User = await service.GetUserById(id);
            UserDTO userDTO = _Mapper.Map<User, UserDTO>(User);

            return Ok(userDTO);


        }

        // POST api/<UserController>
        [HttpPost]
    
        public async Task<ActionResult<UserDTO>> Post([FromBody] RegisterUserDTO user)
        {
      
            User newuser = _Mapper.Map<RegisterUserDTO, User>(user);
           User user1= await service.AddUser(newuser);

            return Ok(user1);
        }
                
  
        [HttpPost]
        [Route("password")]
        public int PostPassword([FromQuery] string password)
        {

            return  service.CheckPassword(password);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> PostLogin([FromQuery] string UserName, string Password)
        {
            User User = await service.Login(UserName, Password);
            UserDTO user  = _Mapper.Map<User, UserDTO>(User);
            if (User != null)
                return Ok(User);

            return NoContent();


        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
            service.UpdateUser(id, value);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
