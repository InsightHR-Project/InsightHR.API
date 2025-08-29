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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_DepartmentMaster]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insert(DepartmentDto dept)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new
            {
                DepartmentName = dept.Name
            });

            return await conn.ExecuteAsync(
                "[dbo].[sp_DepartmentMaster]",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Update(int id, DepartmentDto dept)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new
            {
                DepartmentId = id,
                DepartmentName = dept.Name
            });

            return await conn.ExecuteAsync(
                "[dbo].[sp_DepartmentMaster]",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetById(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { DepartmentId = id });

            return await conn.QueryFirstOrDefaultAsync<dynamic>(
                "[dbo].[sp_DepartmentMaster]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { DepartmentId = id });

            return await conn.ExecuteAsync(
                "[dbo].[sp_DepartmentMaster]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
