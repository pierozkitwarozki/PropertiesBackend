using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize(Policy = "RequireUserRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }



        [HttpPut("edit")]
        public async Task<IActionResult> EditUserAsync(UserToEdit userToEdit)
        {
            try
            {
                await _service.EditAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value, userToEdit);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}