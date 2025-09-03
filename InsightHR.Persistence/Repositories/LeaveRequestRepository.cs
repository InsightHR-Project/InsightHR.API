using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly DapperContext _context;

        public LeaveRequestRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<dynamic>(
                "SP_LeaveRequests",
                new { Flag = 1, JsonData = (string?)null },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(LeaveRequestCreateDto dto)
        {
            using var con = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);

            return await con.ExecuteAsync(
                "SP_LeaveRequests",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(LeaveRequestUpdateDto dto)
        {
            using var con = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);

            return await con.ExecuteAsync(
                "SP_LeaveRequests",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var con = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { id });

            return await con.ExecuteAsync(
                "SP_LeaveRequests",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ManagerDecisionAsync(ManagerDecisionDto dto)
        {
            using var con = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);

            return await con.ExecuteAsync(
                "SP_LeaveRequests",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }
    }
}