using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _context;

        public RoleRepository(DapperContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_RoleMaster]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Insert(RoleDto role)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { RoleName = role.Name });
            return await conn.ExecuteAsync(
                "[dbo].[sp_RoleMaster]",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Update(RoleUpdateDto role)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { RoleId = role.Id, RoleName = role.Name });
            return await conn.ExecuteAsync(
                "[dbo].[sp_RoleMaster]",
                new { Flag = 3, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetRole(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { RoleId = id });
            return await conn.QueryFirstOrDefaultAsync<dynamic>(
                "[dbo].[sp_RoleMaster]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int id)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { RoleId = id });
            return await conn.ExecuteAsync(
                "[dbo].[sp_RoleMaster]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }
    }

}


