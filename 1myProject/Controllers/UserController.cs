﻿
using BL;
using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
//using Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        IUserBL _userBL ;
        IPasswordBL _passwordBL;
        public  UserController(IUserBL userBL, IPasswordBL passwordBL)
        { _userBL = userBL;
           _passwordBL = passwordBL;
        }

        
        //GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user=await _userBL.Get(id);
            return  user != null ? Ok(user) : BadRequest("not found");
        }

        //POST api/<LoginController>
        //[HttpPost("/login")]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> LogIn([FromBody] User clientUser)
        {
           User user = await _userBL.LogIn(clientUser);
            return user == null? Unauthorized() : Ok(user);

        }

      

        //POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User newUser)
        {
            int passwordStrength = await _passwordBL.checkStrangePassword(newUser.Password);

            if (passwordStrength >= 1)
            {
                User user = await _userBL.Post(newUser);
                return user;//return user != null ? CreatedAtAction(nameof(Get), new { id = user.UserId }, user) : BadRequest();
            }
            else
                return passwordStrength == null ? Unauthorized() : BadRequest("Password isn't sronge");
        }
      


        //// PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _userBL.Put(id,userToUpdate);
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {



        }
    }
}

