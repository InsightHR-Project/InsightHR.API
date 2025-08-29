//using InsightHR.Application.Dtos;
//using InsightHR.Application.Interfaces;
//using InsightHR.Persistence.Repositories;
//using InsightHR.Shared.Results;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InsightHR.Infrastructure.Services
//{
//    public class PerformanceReviewService : IPerformanceReviewService
//    {
//        private readonly IPerformanceReviewRepository _reviewRepository;

//        public PerformanceReviewService(IPerformanceReviewRepository reviewRepository) // ✅ FIXED
//        {
//            _reviewRepository = reviewRepository;
//        }

//        public async Task<ApiResponse< IEnumerable<dynamic>>>GetAll(int ? reviewedBy = null)
//        {
//            var reviews = await _reviewRepository.GetAll(reviewedBy);
//            return ApiResponse<IEnumerable<dynamic>>.Ok(reviews, "Performance reviews retrieved successfully.");
//        }

//        public async Task<ApiResponse<string>> Create(PerformanceReviewDto review, int reviewedBy)
//        {
//            await _reviewRepository.Insert(review, reviewedBy); // ✅ fixed
//            return ApiResponse<string>.Ok("Performance review created successfully.");
//        }



//        public async Task<ApiResponse<string>> Update(PerformanceReviewUpdateDto review, int? reviewedBy = null)
//        {
//            await _reviewRepository.Update(review, reviewedBy);
//            return ApiResponse<string>.Ok("Performance review updated successfully.");
//        }


//        public async Task<ApiResponse<string>> Delete(int id)
//        {
//            await _reviewRepository.Delete(id);
//            return ApiResponse<string>.Ok("Performance review deleted successfully.");
//        }


//    }
//}
