using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsightHR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<dynamic>>>> GetAll()
        {
            var result = await _loanService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> Insert([FromForm] LoanInsertDto dto)
        {
            var result = await _loanService.InsertAsync(dto);
            return Ok(result);
        }

        [HttpPost("approve")]
        public async Task<ActionResult<ApiResponse<string>>> Approve([FromForm] LoanApprovalDto dto)
        {
            var result = await _loanService.ApproveAsync(dto);
            return Ok(result);
        }

        [HttpPost("reject")]
        public async Task<ActionResult<ApiResponse<string>>> Reject([FromForm] LoanApprovalDto dto)
        {
            var result = await _loanService.RejectAsync(dto);
            return Ok(result);
        }

    }
}
