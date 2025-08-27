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
    public class AttendanceLogService : IAttendanceLogService
    {

        private readonly IAttendanceLogRepository _repository;

        public AttendanceLogService(IAttendanceLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
        {
            var logs = await _repository.GetAll();
            return ApiResponse<IEnumerable<dynamic>>.Ok(logs, "Fetched attendance logs");
        }

        public async Task<ApiResponse<string>> Create(AttendanceLogDto log)
        {
            var result = await _repository.Insert(log);
            return result > 0
                ? ApiResponse<string>.Ok("Attendance log created successfully")
                : ApiResponse<string>.Fail("Failed to create attendance log");
        }

        public async Task<ApiResponse<string>> Update(AttendanceLogUpdateDto log)
        {
            var result = await _repository.Update(log);
            return result > 0
                ? ApiResponse<string>.Ok("Attendance log updated successfully")
                : ApiResponse<string>.Fail("Failed to update attendance log");
        }

        public async Task<ApiResponse<string>> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return result > 0
                ? ApiResponse<string>.Ok("Attendance log deleted successfully")
                : ApiResponse<string>.Fail("Failed to delete attendance log");
        }
    }
}
