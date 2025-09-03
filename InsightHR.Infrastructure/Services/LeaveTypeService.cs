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
    public class LeaveTypeService : ILeaveTypeService
    {

        private readonly ILeaveTypeRepository _repo;

        public LeaveTypeService(ILeaveTypeRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllLeaveTypesAsync()
        {
            var leaveTypes = await _repo.GetAllAsync();
            return ApiResponse<IEnumerable<dynamic>>.Ok(leaveTypes, "Leave types fetched successfully");
        }

        public async Task<ApiResponse<int>> CreateLeaveTypeAsync(LeaveTypeCreateDto dto)
        {
            var result = await _repo.CreateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave type created successfully")
                : ApiResponse<int>.Fail("Failed to create leave type", 400);
        }

        public async Task<ApiResponse<int>> UpdateLeaveTypeAsync(LeaveTypeUpdateDto dto)
        {
            var result = await _repo.UpdateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave type updated successfully")
                : ApiResponse<int>.Fail("Failed to update leave type", 404);
        }

        public async Task<ApiResponse<int>> DeleteLeaveTypeAsync(int id)
        {
            var result = await _repo.DeleteAsync(id);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Leave type deleted successfully")
                : ApiResponse<int>.Fail("Leave type not found", 404);
        }
    }
}
