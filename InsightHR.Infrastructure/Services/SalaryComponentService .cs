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

        public SalaryComponentService(ISalaryComponentRepository repository)
        {
            _repository = repository;
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
