
using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        ILogger<UserController> _logger;
        IUserBL _userBL ;
        IPasswordBL _passwordBL;
        IMapper _mapper;
        

        public UserController(IUserBL userBL, IPasswordBL passwordBL, IMapper mapper,ILogger<UserController> logger)
        {
          _userBL = userBL;
          _passwordBL = passwordBL;
          _mapper = mapper;
          _logger = logger;
        }



        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user=await _userBL.Get(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO != null ? Ok(userDTO) : BadRequest("not found");
        }

        //POST api/<LoginController>
        //[HttpPost("/login")]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDTO>> LogIn([FromBody] UserDTO clientUser)
        {
            User user =  _mapper.Map<UserDTO, User>(clientUser);
            User loginUser = await _userBL.LogIn(user);
            
           
            //_logger.LogInformation($"Login - userName: {userDTO.Email} at {DateTime.UtcNow.ToLongTimeString()}");
            return loginUser == null? Unauthorized() : Ok(_mapper.Map<User, UserDTO>(loginUser));

        }

        //POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO newUser)
        {
            int passwordStrength = await _passwordBL.checkStrangePassword(newUser.Password);

            if (passwordStrength >= 1)
            {
                User user = _mapper.Map<UserDTO, User>(newUser);
                User userCreated = await _userBL.Post(user);
                UserDTO userDTOCreated = _mapper.Map<User, UserDTO>(userCreated);
                return userDTOCreated;//return user != null ? CreatedAtAction(nameof(Get), new { id = user.UserId }, user) : BadRequest();
            }
            else
                return passwordStrength == null ? Unauthorized() : BadRequest("Password isn't sronge");
        }
      


        //// PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO userToUpdate)
        {
            User user = _mapper.Map<UserDTO, User>(userToUpdate);
            await _userBL.Put(id, user);
        }

    }
}

