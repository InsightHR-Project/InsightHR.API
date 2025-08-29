
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roleService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _roleService.GetById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto role)
        {
            var response = await _roleService.Create(role);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/Role
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleUpdateDto role)
        {
            var response = await _roleService.Update(role);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _roleService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }

}

