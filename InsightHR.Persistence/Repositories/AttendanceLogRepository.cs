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
    public class AttendanceLogRepository : IAttendanceLogRepository
    {
        private readonly DapperContext _context;

        public AttendanceLogRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[SP_AttendanceLogs]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insert(AttendanceLogDto log)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(log);
            return await conn.ExecuteAsync(
                "[dbo].[SP_AttendanceLogs]",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Update(AttendanceLogUpdateDto log)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(log);
            return await conn.ExecuteAsync(
                "[dbo].[SP_AttendanceLogs]",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { id });
            return await conn.ExecuteAsync(
                "[dbo].[SP_AttendanceLogs]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
