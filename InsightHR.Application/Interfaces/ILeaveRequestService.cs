using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ILeaveRequestService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync();
        Task<ApiResponse<int>> CreateAsync(LeaveRequestCreateDto dto);
        Task<ApiResponse<int>> UpdateAsync(LeaveRequestUpdateDto dto);
        Task<ApiResponse<int>> DeleteAsync(int id);
        Task<ApiResponse<int>> ManagerDecisionAsync(ManagerDecisionDto dto);
    }
}
