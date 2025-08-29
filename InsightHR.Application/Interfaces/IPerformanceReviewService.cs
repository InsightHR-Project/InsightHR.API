using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IPerformanceReviewService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll(int? reviewedBy = null);
        Task<ApiResponse<string>> Create(PerformanceReviewDto review, int reviewedBy);
        Task<ApiResponse<string>> Update(PerformanceReviewUpdateDto review, int? reviewedBy = null);
        Task<ApiResponse<string>> Delete(int id);
    }
}
