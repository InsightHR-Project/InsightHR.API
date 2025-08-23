using Dapper;
using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
     public class JobRepository : IJobRepository
        {
            private readonly DapperContext _connectionString;
            public JobRepository(DapperContext context)
            {
            _connectionString = context;
            }

            public async Task<IEnumerable<dynamic>> GetAllAsync()
            {
                using var con = _connectionString.CreateConnection();
            return await con.QueryAsync<IEnumerable<dynamic>>(
                    "SP_JobsMaster",
                    new { Flag = 1, JsonData = (string?)null },
                    commandType: CommandType.StoredProcedure);
            }

            //public async Task<int> CreateAsync(JobCreateDto jobDto)
            //{
            //    using var con = new SqlConnection(_connectionString);
            //    var json = JsonSerializer.Serialize(jobDto);
            //    return await con.ExecuteAsync(
            //        "SP_JobsMaster",
            //        new { Flag = 2, JsonData = json },
            //        commandType: CommandType.StoredProcedure);
            //}

            //public async Task<int> UpdateAsync(JobUpdateDto jobDto)
            //{
            //    using var con = new SqlConnection(_connectionString);
            //    var json = JsonSerializer.Serialize(jobDto);
            //    return await con.ExecuteAsync(
            //        "SP_JobsMaster",
            //        new { Flag = 3, JsonData = json },
            //        commandType: CommandType.StoredProcedure);
            //}

            //public async Task<int> DeleteAsync(int id)
            //{
            //    using var con = new SqlConnection(_connectionString);
            //    var json = JsonSerializer.Serialize(new { id });
            //    return await con.ExecuteAsync(
            //        "SP_JobsMaster",
            //        new { Flag = 4, JsonData = json },
            //        commandType: CommandType.StoredProcedure);
            //}

            public async Task<int> CreateAsync(JobCreateDto jobDto)
            {
                using var con = _connectionString.CreateConnection();

                var json = JsonSerializer.Serialize(new
                {
                    title = jobDto.Title,
                    department_id = jobDto.DepartmentId,
                    status = jobDto.Status,
                    created_by = jobDto.CreatedBy
                });

                return await con.ExecuteAsync(
                    "SP_JobsMaster",
                    new { Flag = 2, JsonData = json },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<int> UpdateAsync(JobUpdateDto jobDto)
            {
                using var con = _connectionString.CreateConnection();

                var json = JsonSerializer.Serialize(new
                {
                    id = jobDto.Id,
                    title = jobDto.Title,
                    department_id = jobDto.DepartmentId,
                    status = jobDto.Status,
                    //updated_at = jobDto.UpdatedAt // optional
                });

                return await con.ExecuteAsync(
                    "SP_JobsMaster",
                    new { Flag = 3, JsonData = json },
                    commandType: CommandType.StoredProcedure);
            }

            public async Task<int> DeleteAsync(int id)
            {
                using var con = _connectionString.CreateConnection();

                var json = JsonSerializer.Serialize(new { id });

                return await con.ExecuteAsync(
                    "SP_JobsMaster",
                    new { Flag = 4, JsonData = json },
                    commandType: CommandType.StoredProcedure);
            }


        }
    }

