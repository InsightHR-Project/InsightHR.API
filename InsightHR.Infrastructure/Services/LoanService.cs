using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            var data = await _loanRepository.GetAllAsync();
            return ApiResponse<IEnumerable<dynamic>>.Ok(data);
        }

        public async Task<ApiResponse<string>> InsertAsync(LoanInsertDto dto)
        {
            var message = await _loanRepository.InsertAsync(dto);
            return ApiResponse<string>.Ok(message);
        }

        public async Task<ApiResponse<string>> ApproveAsync(LoanApprovalDto dto)
        {
            var message = await _loanRepository.ApproveAsync(dto);
            return ApiResponse<string>.Ok(message);
        }

        public async Task<ApiResponse<string>> RejectAsync(LoanApprovalDto dto)
        {
            var message = await _loanRepository.RejectAsync(dto);
            return ApiResponse<string>.Ok(message);
        }

      
    }
}
