using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using BCrypt.Net;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DapperContext _context;

        public AuthRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> Register(RegisterDto user)
        {
            using var conn = _context.CreateConnection();


            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var json = JsonSerializer.Serialize(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = hashedPassword
            });

            return await conn.ExecuteAsync(
                "[dbo].[sp_UserMaster]",
                new { Flag = 4, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> Login(string email)
        {
            using var conn = _context.CreateConnection();

            var json = JsonSerializer.Serialize(new { Email = email });

            return await conn.QueryFirstOrDefaultAsync<dynamic>(
                "[dbo].[sp_UserMaster]",
                new { Flag = 5, JsonData = json },
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
