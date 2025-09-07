using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ILoanService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<string>> InsertAsync(LoanInsertDto dto);
        Task<ApiResponse<string>> ApproveAsync(LoanApprovalDto dto);
        Task<ApiResponse<string>> RejectAsync(LoanApprovalDto dto);
        
    }
    public interface ILoanRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<string> InsertAsync(LoanInsertDto dto);
        Task<string> ApproveAsync(LoanApprovalDto dto);
        Task<string> RejectAsync(LoanApprovalDto dto);

        Task<LoanResponseDto?> GetByIdAsync(int loanId);

        Task<ApiResponse<IEnumerable<dynamic>>> Repayments(int userid);

    }
}
