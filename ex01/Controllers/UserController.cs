
using AutoMapper;
using Entytess;
using Microsoft.AspNetCore.Mvc;
using ODT;
using repository;
using servies;
using System.Diagnostics;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
       private readonly IMapper Mapper;
       private readonly ILogger<UserController> _logger;
       IUserServies _UserServies;

        public UserController(IUserServies UserServies,IMapper mapper,ILogger<UserController>logger)
        {
            _logger = logger;
            Mapper = mapper;
            _UserServies = UserServies;
        }

        // GET: api/<UserController>
        [HttpPost]
         [Route("login")]
        public async Task<ActionResult<User>> Get([FromBody] UserLoginDTO loginDto)
        {
            var userName = loginDto.Email;
            var password = loginDto.Password;
            User user = await _UserServies.getUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NotFound();
            return Ok(user);

        }
      
       
        // POST api/<UserController>
        [HttpPost]
       
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            User user = Mapper.Map<UserDTO, User>(userDTO);
            
                //var x = 4;
                //var y = x / 0;
             User newUser=   await _UserServies.CreateNewUser(user);
            if (newUser!=null) { 
                _logger.LogInformation("Login attemted with User Name, {0} and password {1}", userDTO.Email, userDTO.Password);
                 return  CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
            else { 
                return NoContent();
               }


        }
        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            
            if (password != "")
            {
               
                return await _UserServies.check(password);
            }
            return -1;

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
         await  _UserServies.Put(id, userToUpdate);
           



        }
        
    }
}
