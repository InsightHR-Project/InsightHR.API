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
    public class ShiftRepository : IShiftRepository
    {
        private readonly DapperContext _context;

        public ShiftRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_ShiftMaster]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insert(ShiftDto shift)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new
            {
                ShiftName = shift.Name,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime
            });

            return await conn.ExecuteAsync(
                "[dbo].[sp_ShiftMaster]",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Update(int id, ShiftDto shift)
        {
            using var conn = _context.CreateConnection();

       
            var json = JsonSerializer.Serialize(new
            {
               
                ShiftName = shift.Name,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime
            });

            return await conn.ExecuteAsync(
                "[dbo].[sp_ShiftMaster]",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<dynamic> GetShift(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { ShiftId = id });

            return await conn.QueryFirstOrDefaultAsync<dynamic>(
                "[dbo].[sp_ShiftMaster]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { ShiftId = id });

            return await conn.ExecuteAsync(
                "[dbo].[sp_ShiftMaster]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
