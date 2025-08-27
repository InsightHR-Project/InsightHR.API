using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationsController(IApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationDto dto)
        {
            var response = await _service.Create(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ApplicationUpdateDto dto)
        {
            var response = await _service.Update(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleInterview([FromBody] ScheduleInterviewDto dto)
        {
            var response = await _service.ScheduleInterview(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("final-selection")]
        public async Task<IActionResult> FinalSelection([FromBody] FinalSelectionDto dto)
        {
            var response = await _service.FinalSelection(dto);
            return StatusCode(response.StatusCode, response);
        }

    }
}
