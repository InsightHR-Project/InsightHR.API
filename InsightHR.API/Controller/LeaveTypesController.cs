using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveTypeService _service;

        public LeaveTypesController(ILeaveTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllLeaveTypesAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveTypeCreateDto dto)
        {
            var response = await _service.CreateLeaveTypeAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LeaveTypeUpdateDto dto)
        {
            var response = await _service.UpdateLeaveTypeAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteLeaveTypeAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
