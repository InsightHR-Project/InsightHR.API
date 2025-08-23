using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        // GET: api/Shift
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _shiftService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/Shift/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _shiftService.GetById(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/Shift
        [HttpPost]
        public async Task<IActionResult> Create( ShiftDto shift)
        {
            var response = await _shiftService.Create(shift);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/Shift/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, ShiftDto shift)
        {
            var response = await _shiftService.Update(id,shift);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/Shift/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _shiftService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
