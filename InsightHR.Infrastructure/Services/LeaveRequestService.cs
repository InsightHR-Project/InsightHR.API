using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;

namespace InsightHR.Infrastructure.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repo;

        public LeaveRequestService(ILeaveRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return ApiResponse<IEnumerable<dynamic>>.Ok(data, "Leave requests fetched successfully");
        }

        public async Task<ApiResponse<int>> CreateAsync(LeaveRequestCreateDto dto)
        {
            var result = await _repo.CreateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave request created successfully")
                : ApiResponse<int>.Fail("Failed to create leave request", 400);
        }

        public async Task<ApiResponse<int>> UpdateAsync(LeaveRequestUpdateDto dto)
        {
            var result = await _repo.UpdateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave request updated successfully")
                : ApiResponse<int>.Fail("Failed to update leave request", 400);
        }

        public async Task<ApiResponse<int>> DeleteAsync(int id)
        {
            var result = await _repo.DeleteAsync(id);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave request deleted successfully")
                : ApiResponse<int>.Fail("Leave request not found", 404);
        }

        public async Task<ApiResponse<int>> ManagerDecisionAsync(ManagerDecisionDto dto)
        {
            var result = await _repo.ManagerDecisionAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Manager decision applied successfully")
                : ApiResponse<int>.Fail("Failed to update decision", 400);
        }
    }

}
