using Dapper;
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
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<dynamic>(
                "[dbo].[sp_UserMaster]",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetById(int userId)
        {
            using var conn = _context.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<dynamic>(
                "[dbo].[sp_UserMaster]",
                new { Flag = 2, UserId = userId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> Delete(int userId)
        {
            using var conn = _context.CreateConnection();
            return await conn.ExecuteAsync(
                "[dbo].[sp_UserMaster]",
                new { Flag = 3, UserId = userId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> ChangeRole(int userId, int newRoleId)
        {
            using var conn = _context.CreateConnection();
            var json = JsonSerializer.Serialize(new { UserId = userId, RoleId = newRoleId });
            return await conn.ExecuteAsync(
                "[dbo].[sp_UserMaster]",
                new { Flag = 7, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
