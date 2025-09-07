using Application.Common.Interfaces;
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
    public class SalaryComponentService : ISalaryComponentService
    {
        private readonly ISalaryComponentRepository _repository;
        private readonly INotificationService _notificationService;
        private readonly IwagesRepositery _wagesrepo;

        public SalaryComponentService(ISalaryComponentRepository repository, INotificationService notificationService, IwagesRepositery wagesrepo)
        {
            _repository = repository;
            _notificationService = notificationService;
            _wagesrepo = wagesrepo;
        }

        public async Task<ApiResponse<IEnumerable<SalaryComponentResponseDto>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return ApiResponse<IEnumerable<SalaryComponentResponseDto>>.Ok(result);
        }

        public async Task<ApiResponse<SalaryComponentResponseDto>> InsertAsync(SalaryComponentInsertDto dto)
        {
            if (dto.WagesId <= 0)
                return ApiResponse<SalaryComponentResponseDto>.Fail("SalaryId is required");

            var result = await _repository.InsertAsync(dto);
            if (result == null)
                return ApiResponse<SalaryComponentResponseDto>.Fail("Insert failed");

            // 2) Get the wages row to find which user to notify
            var wages = await _wagesrepo.GetwagesbyID(new GetWagesByIdRequest { Id = dto.WagesId });
            if (wages == null)
                return ApiResponse<SalaryComponentResponseDto>.Ok(result, "Inserted, but Wages not found. Notification skipped.");

            // 3) Build a simple message (no ComponentName/Amount needed)
            var message = $"Hello, your salary has been Credited your account. for {dto.PayPeriod}.";
            if (dto.Deductions > 0)
                message += $" Deductions applied: {dto.Deductions}.";

            // 4) Send notification (NotificationService will fetch user email internally)
            await _notificationService.SendNotificationAsync(wages.UserId, message);

            return ApiResponse<SalaryComponentResponseDto>.Ok(result, "Salary Component inserted successfully");
        }

        public async Task<ApiResponse<SalaryComponentResponseDto>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return ApiResponse<SalaryComponentResponseDto>.Fail("Salary Component not found", 404);

            return ApiResponse<SalaryComponentResponseDto>.Ok(result);
        }

    }
}
