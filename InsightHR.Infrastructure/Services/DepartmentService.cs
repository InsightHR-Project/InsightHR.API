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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _deptRepository;

        public DepartmentService(IDepartmentRepository deptRepository)
        {
            _deptRepository = deptRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
        {
            var depts = await _deptRepository.GetAll();
            return ApiResponse<IEnumerable<dynamic>>.Ok(depts, "Departments retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Create(DepartmentDto dept)
        {
            await _deptRepository.Insert(dept);
            return ApiResponse<string>.Ok("Department created successfully.");
        }

        public async Task<ApiResponse<string>> Update(int id, DepartmentDto dept)
        {
            await _deptRepository.Update(id, dept);
            return ApiResponse<string>.Ok("Department updated successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetById(int id)
        {
            var dept = await _deptRepository.GetById(id);
            if (dept == null)
                return ApiResponse<dynamic>.Fail("Department not found.", 404);

            return ApiResponse<dynamic>.Ok(dept, "Department retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Delete(int id)
        {
            await _deptRepository.Delete(id);
            return ApiResponse<string>.Ok("Department deleted successfully.");
        }
    }
}
