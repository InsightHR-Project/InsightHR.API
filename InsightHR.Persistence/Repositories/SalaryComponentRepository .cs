using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System.Data;
using System.Text.Json;

namespace InsightHR.Persistence.Repositories
{
    public class SalaryComponentRepository : ISalaryComponentRepository
    {
        private readonly DapperContext _context;

        public SalaryComponentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalaryComponentResponseDto>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();

            var result = await connection.QueryAsync<SalaryComponentResponseDto>(
                "sp_SalaryComponents",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<SalaryComponentResponseDto> InsertAsync(SalaryComponentInsertDto dto)
        {
            using var connection = _context.CreateConnection();

            var json = JsonSerializer.Serialize(dto);

            var result = await connection.QueryFirstOrDefaultAsync<SalaryComponentResponseDto>(
                "sp_SalaryComponents",
                new { Flag = 2, JsonData = json },
                commandType: CommandType.StoredProcedure
            );

            return result!;
        }

        public async Task<SalaryComponentResponseDto?> GetByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.QueryFirstOrDefaultAsync<SalaryComponentResponseDto>(
                "sp_SalaryComponents",
                new { Flag = 3, Id = id },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
