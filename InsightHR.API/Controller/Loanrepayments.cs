using InsightHR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsightHR.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loanrepayments : ControllerBase
    {
        private readonly IloanRepayments _repo;

        public Loanrepayments(IloanRepayments repo)
        {
            _repo = repo;
        }

        [HttpGet("get-repayments")]
        public async Task<IActionResult> GetAll( int userId)
        {
            var result = await _repo.GetAllAsync(userId);
            return Ok(result);
        }
    }
}
