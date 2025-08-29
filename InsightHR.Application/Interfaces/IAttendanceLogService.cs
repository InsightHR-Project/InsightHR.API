using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IAttendanceLogService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<string>> Create(AttendanceLogDto log);
        Task<ApiResponse<string>> Update(AttendanceLogUpdateDto log);
        Task<ApiResponse<string>> Delete(int id);
    }
}
