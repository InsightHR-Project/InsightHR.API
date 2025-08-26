using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ISalaryComponentRepository
    {
        Task<IEnumerable<SalaryComponentResponseDto>> GetAllAsync();
        Task<SalaryComponentResponseDto> InsertAsync(SalaryComponentInsertDto dto);
        Task<SalaryComponentResponseDto?> GetByIdAsync(int id);
    }
    public interface ISalaryComponentService
    {
        Task<ApiResponse<IEnumerable<SalaryComponentResponseDto>>> GetAllAsync();
        Task<ApiResponse<SalaryComponentResponseDto>> InsertAsync(SalaryComponentInsertDto dto);
        Task<ApiResponse<SalaryComponentResponseDto>> GetByIdAsync(int id);
    }
}
