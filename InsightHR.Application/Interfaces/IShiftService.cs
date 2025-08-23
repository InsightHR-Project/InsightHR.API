using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IShiftService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<string>> Create(ShiftDto shift);
        Task<ApiResponse<string>> Update(int id, ShiftDto shift);
        Task<ApiResponse<dynamic>> GetById(int id);
        Task<ApiResponse<string>> Delete(int id);
    }
}
