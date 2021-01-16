using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _service;

        public DistrictController(IDistrictService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DistrictToAdd districtToAdd)
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

        [HttpDelete("{districtId}")]
        public async Task<IActionResult> DeleteAsync(int districtId)
        {
            try
            {
                return Ok(await _service.DeleteAsync(districtId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{districtId}")]
        public async Task<IActionResult> GetSingleAsync(int districtId)
        {
            try
            {
                return Ok(await _service.GetAsync(districtId));
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