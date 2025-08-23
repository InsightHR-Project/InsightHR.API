using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Repositories;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }



        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAllJobsAsync()
        {
            var jobs = await _jobRepository.GetAllAsync();
            return ApiResponse<IEnumerable<dynamic>>.Ok(jobs, "Jobs fetched successfully");
        }

        public async Task<ApiResponse<int>> CreateJobAsync(JobCreateDto dto)
        {
            var result = await _jobRepository.CreateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Job created successfully")
                : ApiResponse<int>.Fail("Failed to create job", 400);
        }

        public async Task<ApiResponse<int>> UpdateJobAsync(JobUpdateDto dto)
        {
            var result = await _jobRepository.UpdateAsync(dto);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Job updated successfully")
                : ApiResponse<int>.Fail("Failed to update job", 404);
        }

        public async Task<ApiResponse<int>> DeleteJobAsync(int id)
        {
            var result = await _jobRepository.DeleteAsync(id);
            return result > 0
                ? ApiResponse<int>.Ok(result, "Job deleted successfully")
                : ApiResponse<int>.Fail("Job not found", 404);
        }
    }
}
