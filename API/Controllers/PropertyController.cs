using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Policy = "RequireUserRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PropertyToAdd propertyToAdd)
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

        [HttpDelete("{propertyId}")]
        public async Task<IActionResult> DeleteAsync(int propertyId)
        {
            try
            {
                return Ok(await _service.DeleteAsync(propertyId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetSingleAsync(int propertyId)
        {
            try
            {
                return Ok(await _service.GetAsync(propertyId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("for-district/{districtId}")]
        public async Task<IActionResult> GetForDistrictAsync(int districtId)
        {
            try
            {
                return Ok(await _service.GetForDistrictAsync(districtId));
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