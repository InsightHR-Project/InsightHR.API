using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InsightHR.Persistence.Repositories
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly DapperContext _context;

        public LeaveTypeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            using var con = _context.CreateConnection();
            return await con.QueryAsync<dynamic>(
                "sp_LeaveTypesMaster",
                new { Flag = 1, JsonData = (string?)null },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreateAsync(LeaveTypeCreateDto dto)
        {
            using var con = _context.CreateConnection();

            var json = JsonSerializer.Serialize(new
            {
                name = dto.Name,
                description = dto.Description,
                max_days_per_year = dto.MaxDaysPerYear
            });

            // ExecuteAsync returns number of affected rows
            return await con.ExecuteAsync(
                "sp_LeaveTypesMaster",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateAsync(LeaveTypeUpdateDto dto)
        {
            using var con = _context.CreateConnection();

            var json = JsonSerializer.Serialize(new
            {
                id = dto.Id,
                name = dto.Name,
                description = dto.Description,
                max_days_per_year = dto.MaxDaysPerYear
            });

            return await con.ExecuteAsync(
                "sp_LeaveTypesMaster",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var con = _context.CreateConnection();

            var json = JsonSerializer.Serialize(new { id });

            return await con.ExecuteAsync(
                "sp_LeaveTypesMaster",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure);
        }
    }
}
