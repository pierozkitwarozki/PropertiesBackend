using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPropertyController : ControllerBase
    {
        private readonly IUserPropertyService _service;

        public UserPropertyController(IUserPropertyService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserPropertyToAdd propertyToAdd)
        {
            try
            {
                return Ok(await _service.AddAsync(propertyToAdd));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{userId}/{propertyId}")]
        public async Task<IActionResult> DeleteAsync(int userId, int propertyId)
        {
            try
            {
                return Ok(await _service.DeleteAsync(userId, propertyId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId}/{propertyId}")]
        public async Task<IActionResult> GetSingleAsync(int userId, int propertyId)
        {
            try
            {
                return Ok(await _service.GetSingleAsync(userId, propertyId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("for-user/{userId}")]
        public async Task<IActionResult> GetForDistrictAsync(int userId)
        {
            try
            {
                return Ok(await _service.GetForUserAsync(userId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}