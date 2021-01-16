using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;    
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserToLogin userToLogin)
        {
            try 
            {
                return Ok(await _service.LoginAsync(userToLogin));
            }
            catch(Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserToRegister userToRegister)
        {
            try 
            {
                return Ok(await _service.RegisterAsync(userToRegister));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}