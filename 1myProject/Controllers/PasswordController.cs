
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
        // GET api/<PasswordController>/5
      
        IPasswordBL _PasswordBL;
        public PasswordController(IPasswordBL passwordBL)
        { _PasswordBL = passwordBL; }
        // POST api/<PasswordController>
        [HttpPost]

        public async Task<ActionResult<int>> Post([FromBody] string password)
        {
                int passwordStrength = await _PasswordBL.CheckStrangePassword(password);
                return passwordStrength == null ? Unauthorized() : Ok(passwordStrength);
        }

      
    }
}
