using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewService _reviewService;

        public PerformanceReviewController(IPerformanceReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? reviewedBy)
        {
            var response = await _reviewService.GetAll(reviewedBy);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PerformanceReviewDto review, [FromQuery] int reviewedBy)
        {
            var response = await _reviewService.Create(review, reviewedBy);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PerformanceReviewUpdateDto review, [FromQuery] int? reviewedBy)
        {
            var response = await _reviewService.Update(review, reviewedBy);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _reviewService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
