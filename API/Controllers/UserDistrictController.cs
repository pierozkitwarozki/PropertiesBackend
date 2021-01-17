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
    public class UserDistrictController : ControllerBase
    {
        private readonly IUserDistrictService _service;

        public UserDistrictController(IUserDistrictService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UserDistrictToAdd districtToAdd)
        {
            try
            {
                return Ok(await _service.AddAsync(districtToAdd));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{userId}/{districtId}")]
        public async Task<IActionResult> DeleteAsync(int userId, int districtId)
        {
            try
            {
                return Ok(await _service.DeleteAsync(userId, districtId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId}/{districtId}")]
        public async Task<IActionResult> GetSingleAsync(int userId, int districtId)
        {
            try
            {
                return Ok(await _service.GetSingleAsync(userId, districtId));
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