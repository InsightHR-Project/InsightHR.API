using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ILeaveTypeService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllLeaveTypesAsync();
        Task<ApiResponse<int>> CreateLeaveTypeAsync(LeaveTypeCreateDto dto);
        Task<ApiResponse<int>> UpdateLeaveTypeAsync(LeaveTypeUpdateDto dto);
        Task<ApiResponse<int>> DeleteLeaveTypeAsync(int id);
    }
}
