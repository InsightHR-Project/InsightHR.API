using Application.Common.Interfaces;  // same as SalaryComponentService
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly INotificationService _notificationService;

        public LoanService(ILoanRepository loanRepository, INotificationService notificationService)
        {
            _loanRepository = loanRepository;
            _notificationService = notificationService;
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

            var loan = await _loanRepository.GetByIdAsync(dto.loan_id);
            if (loan != null)
            {
                var notifyMessage = $"Hello, your loan request (#{loan.Id}) has been approved by HR.";
                await _notificationService.SendNotificationAsync(loan.UserId, notifyMessage);
            }

            return ApiResponse<string>.Ok(message, "Loan approved and user notified");
        }

        public async Task<ApiResponse<string>> RejectAsync(LoanApprovalDto dto)
        {
            var message = await _loanRepository.RejectAsync(dto);

            var loan = await _loanRepository.GetByIdAsync(dto.loan_id);
            if (loan != null)
            {
                var notifyMessage = $"Hello, your loan request (#{loan.Id}) has been rejected by HR.";
                await _notificationService.SendNotificationAsync(loan.UserId, notifyMessage);
            }

            return ApiResponse<string>.Ok(message, "Loan rejected and user notified");
        }
    }
}
