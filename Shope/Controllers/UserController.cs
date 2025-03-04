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
        private readonly ILogger<UserController> _logger;
        IServiceUser service ;
        IMapper _Mapper;
        public UserController(IServiceUser _serviceUser,IMapper mapper, ILogger<UserController> logger)
        {
            _logger = logger;
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



        [HttpPost]
        [Route("password")]
        public IActionResult PostPassword([FromQuery] string password)
        {
            int score = service.CheckPassword(password);
            return score < 3 ? BadRequest(score) : Ok(score);

        }

        [HttpPost]
     
        public async Task<ActionResult<UserDTO>> Post([FromBody] RegisterUserDTO user)
        {
            try
            {
                User newUser = _Mapper.Map<RegisterUserDTO, User>(user);
                User userDTO = await service.AddUser(newUser);

                UserDTO newUserDTO = _Mapper.Map<User, UserDTO>(userDTO);//////////////////////////////////////////////////////////
                if (newUserDTO != null)
                    return CreatedAtAction(nameof(Get), new { id = user.UserName }, newUserDTO);
                else
                    if (!ModelState.IsValid)

                {

                    var errors = ModelState.SelectMany(ms => ms.Value.Errors)

                    .Select(error => error.ErrorMessage)

                    .ToList();

                    return BadRequest(errors); // מחזיר את השגיאות

                }


                return BadRequest("password week");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> PostLogin([FromQuery] string UserName, string Password)
        {

           
            User User = await service.Login(UserName, Password);
            UserDTO userDTO  = _Mapper.Map<User, UserDTO>(User);
            if (userDTO != null)
            {
                _logger.LogInformation("login attempted with user nsme,{0}and password {1}", UserName, Password);
                return Ok(userDTO);
            }
               

            // החזרת השגיאות מה-DTO
            return BadRequest(ModelState);
        


        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] RegisterUserDTO value)
        {

            User DuplicateUser = await service.ValidateDuplicateUser(value.UserName, value.password);
            if (DuplicateUser != null && DuplicateUser.UserId != id)
            {
                return Conflict("Duplicate User");
            }
            int score = service.CheckPassword(value.password);
            if (score < 3)
            {
                return UnprocessableEntity("week password");
            }

            User user = _Mapper.Map<RegisterUserDTO, User>(value);
            User userUpdate = await service.updateuser(id, DuplicateUser != null ? DuplicateUser : user);
            if (userUpdate != null)
                return Ok(userUpdate);
            else
                return BadRequest();




        }

        // DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
