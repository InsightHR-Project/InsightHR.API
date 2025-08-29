using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryComponentController : ControllerBase
    {
        private readonly ISalaryComponentService _service;

        public SalaryComponentController(ISalaryComponentService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ApiResponse<IEnumerable<SalaryComponentResponseDto>>>> GetAll()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<ApiResponse<SalaryComponentResponseDto>>> Insert([FromBody] SalaryComponentInsertDto dto)
        {
            var response = await _service.InsertAsync(dto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<SalaryComponentResponseDto>>> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return Ok(response);
        }
    }
}
