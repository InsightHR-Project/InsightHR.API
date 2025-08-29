using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _adminService;

        public UserController(IUserService adminService)
        {
            _adminService = adminService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _adminService.GetAll();
            return StatusCode(result.StatusCode, result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _adminService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _adminService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}/role/{roleId}")]
        public async Task<IActionResult> ChangeRole(int id, int roleId)
        {
            var result = await _adminService.ChangeRole(id, roleId);
            return StatusCode(result.StatusCode, result);
        }
    }
}

