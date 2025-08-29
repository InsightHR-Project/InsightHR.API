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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DapperContext _context;

        public ApplicationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insert(ApplicationDto dto)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);
            return await conn.ExecuteAsync(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Update(ApplicationUpdateDto dto)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);
            return await conn.ExecuteAsync(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { id });
            return await conn.ExecuteAsync(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> ScheduleInterview(ScheduleInterviewDto dto)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);
            return await conn.ExecuteAsync(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> FinalSelection(FinalSelectionDto dto)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(dto);
            return await conn.ExecuteAsync(
                "[dbo].[SP_ApplicationsMaster]",
                new { Flag = 6, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
