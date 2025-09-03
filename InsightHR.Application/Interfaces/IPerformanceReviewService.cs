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
        Task<ApiResponse<IEnumerable<dynamic>>> GetAllReviewsAsync(int? reviewedBy = null);
        Task<ApiResponse<int>> CreateReviewAsync(PerformanceReviewCreateDto dto);
        Task<ApiResponse<int>> UpdateReviewAsync(PerformanceReviewUpdateDto dto);
        Task<ApiResponse<int>> DeleteReviewAsync(int id);
    }
}
