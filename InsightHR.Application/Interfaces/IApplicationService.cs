using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<string>> Create(ApplicationDto dto);
        Task<ApiResponse<string>> Update(ApplicationUpdateDto dto);
        Task<ApiResponse<string>> Delete(int id);
        Task<ApiResponse<string>> ScheduleInterview(ScheduleInterviewDto dto);
        Task<ApiResponse<string>> FinalSelection(FinalSelectionDto dto);
    }
}
