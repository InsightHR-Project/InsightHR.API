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
    public class PerformanceReviewService : IPerformanceReviewService
    {
        private readonly IPerformanceReviewRepository _repo;

        public PerformanceReviewService(IPerformanceReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllReviewsAsync(int? reviewedBy = null)
        {
            var reviews = await _repo.GetAllAsync(reviewedBy);
            return ApiResponse<IEnumerable<dynamic>>.Ok(reviews, "Performance reviews fetched successfully");
        }

        public async Task<ApiResponse<int>> CreateReviewAsync(PerformanceReviewCreateDto dto)
        {
            var result = await _repo.CreateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Performance review created successfully")
                : ApiResponse<int>.Fail("Failed to create performance review", 400);
        }

        public async Task<ApiResponse<int>> UpdateReviewAsync(PerformanceReviewUpdateDto dto)
        {
            var result = await _repo.UpdateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Performance review updated successfully")
                : ApiResponse<int>.Fail("Failed to update performance review", 404);
        }

        public async Task<ApiResponse<int>> DeleteReviewAsync(int id)
        {
            var result = await _repo.DeleteAsync(id);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Performance review deleted successfully")
                : ApiResponse<int>.Fail("Performance review not found", 404);
        }
    }
}
