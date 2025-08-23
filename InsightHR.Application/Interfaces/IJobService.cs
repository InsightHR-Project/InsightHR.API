using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IJobService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllJobsAsync();
        Task<ApiResponse<int>> CreateJobAsync(JobCreateDto dto);
        Task<ApiResponse<int>> UpdateJobAsync(JobUpdateDto dto);
        Task<ApiResponse<int>> DeleteJobAsync(int id);
    }
}
