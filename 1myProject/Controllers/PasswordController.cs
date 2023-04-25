
using Microsoft.AspNetCore.Mvc;
using BL;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _1myProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        // PasswordBL passwordBL = new();
        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        IPasswordBL _PasswordBL;
        public PasswordController(IPasswordBL passwordBL)
        { _PasswordBL = passwordBL; }
        // POST api/<PasswordController>
        [HttpPost]

        public async Task<ActionResult<int>> Post([FromBody] string password)
        {
                int passwordStrength = await _PasswordBL.checkStrangePassword(password);
                return passwordStrength == null ? Unauthorized() : Ok(passwordStrength);
        }

      
    }
}
