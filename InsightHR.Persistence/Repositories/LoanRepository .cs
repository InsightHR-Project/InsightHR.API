using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using InsightHR.Shared.Results;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DapperContext _context;

        public LoanRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@flag", 1, DbType.Int32);

            var result = await connection.QueryAsync<dynamic>(
                "sp_trndbl_loans_json",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }


        public async Task<string> InsertAsync(LoanInsertDto dto)
        {
            using var connection = _context.CreateConnection();
            var jsonData = JsonSerializer.Serialize(new
            {
                user_id = dto.UserId,
                amount = dto.Amount,
                reason = dto.Reason,
                tenure_months = dto.TenureMonths,
                sanction_letter_path = dto.SanctionLetterPath,
                wages_id = dto.WagesId,
                from_date = dto.FromDate
            });

            var parameters = new DynamicParameters();
            parameters.Add("@flag", 2, DbType.Int32);
            parameters.Add("@jsondata", jsonData, DbType.String);

            var result = await connection.QueryFirstOrDefaultAsync<string>(
                "sp_trndbl_loans_json",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result ?? "Insert failed";
        }

        public async Task<string> ApproveAsync(LoanApprovalDto dto)
        {
            using var connection = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);

            var parameters = new DynamicParameters();
            parameters.Add("@flag", 3, DbType.Int32);
            parameters.Add("@jsondata", json, DbType.String);

            var result = await connection.QueryFirstOrDefaultAsync<string>(
                "sp_trndbl_loans_json",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result ?? "Approval failed";
        }

        public async Task<string> RejectAsync(LoanApprovalDto dto)
        {
            using var connection = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);

            var parameters = new DynamicParameters();
            parameters.Add("@flag", 4, DbType.Int32);
            parameters.Add("@jsondata", json, DbType.String);

            var result = await connection.QueryFirstOrDefaultAsync<string>(
                "sp_trndbl_loans_json",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result ?? "Rejection failed";
        }

        public async Task<LoanResponseDto?> GetByIdAsync(int loanId)

        {
            using var conn = _context.CreateConnection();

            var json = JsonSerializer.Serialize(new { loan_id = loanId });

            var parameters = new DynamicParameters();
            parameters.Add("@flag",5, DbType.Int32);
            parameters.Add("@jsondata", json, DbType.String);

            var res = await conn.QueryFirstOrDefaultAsync<LoanResponseDto?>(
                       "sp_trndbl_loans_json",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return res;
        }
        public async Task<ApiResponse<IEnumerable<dynamic>>> Repayments(int userid)
        {
            using var conn = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@user_Id", userid, DbType.Int32);

            var result = await conn.QueryAsync(
                "sp_auto_loan_repayment",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            if (result == null || !result.Any())
            {
                return  ApiResponse<IEnumerable<dynamic>>.Fail("No repayments found",404);
            }

            return  ApiResponse<IEnumerable<dynamic>>.Ok(result, "Repayments fetched successfully");
        }

    }
}
