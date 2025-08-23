using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Repositories;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
        {
            var shifts = await _shiftRepository.GetAll();
            return ApiResponse<IEnumerable<dynamic>>.Ok(shifts, "Shifts retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Create(ShiftDto shift)
        {
            await _shiftRepository.Insert(shift);
            return ApiResponse<string>.Ok("Shift created successfully.", "The shift was successfully added");
        }

        public async Task<ApiResponse<string>> Update(int id, ShiftDto shift)
        {
            await _shiftRepository.Update(id,shift);
            return ApiResponse<string>.Ok("Shift updated successfully.", "The shift details have been successfully updated.");
        }

        public async Task<ApiResponse<dynamic>> GetById(int id)
        {
            var shift = await _shiftRepository.GetShift(id);
            if (shift == null)
                return ApiResponse<dynamic>.Fail("Shift not found.", 404);

            return ApiResponse<dynamic>.Ok(shift, "Shift retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Delete(int id)
        {
            await _shiftRepository.Delete(id);
            return ApiResponse<string>.Ok("Shift deleted successfully.");
        }
    }
}
