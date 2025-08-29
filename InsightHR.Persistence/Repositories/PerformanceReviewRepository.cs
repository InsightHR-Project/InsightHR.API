//using Dapper;
//using InsightHR.Application.Dtos;
//using InsightHR.Application.Interfaces;
//using InsightHR.Persistence.Context;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace InsightHR.Persistence.Repositories
//{
//    public class PerformanceReviewRepository : IPerformanceReviewRepository
//    {
//        private readonly DapperContext _context;

//        public PerformanceReviewRepository(DapperContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<dynamic>> GetAll(int? reviewedBy = null)
//        {
//            using var conn = _context.CreateConnection();
//            return await conn.QueryAsync<dynamic>(
//                "[dbo].[SP_PerformanceReviews]",
//                new { Flag = 1, reviewed_by = reviewedBy },
//                commandType: CommandType.StoredProcedure
//            );
//        }

//        public async Task<int> Insert(PerformanceReviewDto review, int reviewedBy)
//        {
//            using var conn = _context.CreateConnection();
//            var json = JsonSerializer.Serialize(new
//            {
//                user_id = review.UserId,
//                review_period = review.ReviewPeriod,
//                score = review.Score,
//                comments = review.Comments
//            });
//            return await conn.ExecuteAsync(
//                "[dbo].[SP_PerformanceReviews]",
//                new { Flag = 2, JsonData = json, reviewed_by = reviewedBy },
//                commandType: CommandType.StoredProcedure
//            );
//        }

//        public async Task<int> Update(PerformanceReviewUpdateDto review, int? reviewedBy = null)
//        {
//            using var conn = _context.CreateConnection();
//            var json = JsonSerializer.Serialize(new
//            {
//                id = review.Id,
//                user_id = review.UserId,
//                review_period = review.ReviewPeriod,
//                score = review.Score,
//                comments = review.Comments
//            });
//            return await conn.ExecuteAsync(
//                "[dbo].[SP_PerformanceReviews]",
//                new { Flag = 3, JsonData = json, reviewed_by = reviewedBy },
//                commandType: CommandType.StoredProcedure
//            );
//        }

//        public async Task<int> Delete(int id)
//        {
//            using var conn = _context.CreateConnection();
//            var json = JsonSerializer.Serialize(new { id });
//            return await conn.ExecuteAsync(
//                "[dbo].[SP_PerformanceReviews]",
//                new { Flag = 4, JsonData = json },
//                commandType: CommandType.StoredProcedure
//            );
//        }

//        public Task<int> ReviewInsert(PerformanceReviewDeleteDto review, int reviewedBy)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
