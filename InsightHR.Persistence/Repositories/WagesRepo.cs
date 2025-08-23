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
    public class WagesRepo : IwagesRepositery
    {
        private readonly DapperContext _conn;

        public WagesRepo(DapperContext conn)
        {
            _conn = conn;
        }

        public async Task<int> AddWagesAsync(WagesRequest request)
        {
            using var conn = _conn.CreateConnection();

            var json = JsonSerializer.Serialize(request);

            var parameters = new DynamicParameters();
            parameters.Add("@Flag", 2);
            parameters.Add("@JsonData", json);

            return await conn.ExecuteAsync(
                  "sp_EmployeeWage",
                  parameters,
                  commandType: CommandType.StoredProcedure,
                  commandTimeout: 60);
        }

        public async Task<IEnumerable<WagesResponse>> Getwages()
        {
            using (var connection = _conn.CreateConnection())
            {
                var result = await connection.QueryAsync<WagesResponse>(
                    "sp_EmployeeWage",
                    new { Flag = 1, JsonData = (string)null },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<int> UpdateWagesAsync(UpdateWagesRequest request)
        {
            var json = JsonSerializer.Serialize(new
            {
                id = request.Id,
                employee_wages = request.EmployeeWages
            }
                );
            var parameters = new DynamicParameters();
            parameters.Add("@flag", 3)
            ; parameters.Add("@jsonData", json);

            using var conn = _conn.CreateConnection();

            return await conn.ExecuteAsync(
                "sp_EmployeeWage",
                parameters,
                 commandType: CommandType.StoredProcedure
                );
        }
        public async Task<int> DeleteWages(DeleteWagesRequest deleteWages)
        {

            var json = JsonSerializer.Serialize(
            new
            {
                WageId = deleteWages.Id,
            });
            var parameters = new DynamicParameters();

            parameters.Add("@flag", 5);
            parameters.Add("@jsonData", json);

            using var connection = _conn.CreateConnection();


            return await connection.ExecuteAsync(
                "sp_EmployeeWage",
                parameters,
               commandType: CommandType.StoredProcedure,
                commandTimeout: 60
                );
        }
        public async Task<WagesResponse> GetwagesbyID(GetWagesByIdRequest getWagesById)
        {
            using var connection = _conn.CreateConnection();

            var json = JsonSerializer.Serialize(new
            {
                WageId = getWagesById.Id
            });

            var parameters = new DynamicParameters();
            parameters.Add("flag", 4);
            parameters.Add("@jsonData", json);

            return await connection.QueryFirstOrDefaultAsync<WagesResponse>("sp_EmployeeWage",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
                );
        }
    }
}
