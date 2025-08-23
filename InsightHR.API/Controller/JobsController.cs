using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return StatusCode(jobs.StatusCode, jobs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobCreateDto dto)
        {
            var response = await _jobService.CreateJobAsync(dto);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPut]
        public async Task<IActionResult> Update(JobUpdateDto dto)
        {
            var response = await _jobService.UpdateJobAsync(dto);
            return StatusCode(response.StatusCode, response);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _jobService.DeleteJobAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
