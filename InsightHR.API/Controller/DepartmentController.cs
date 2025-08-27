using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _departmentService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _departmentService.GetById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentDto department)
        {
            var response = await _departmentService.Create(department);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/Department/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentDto department)
        {
            var response = await _departmentService.Update(id, department);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _departmentService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
