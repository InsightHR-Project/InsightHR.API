using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<string>> Create(DepartmentDto dept);
        Task<ApiResponse<string>> Update(int id, DepartmentDto dept);
        Task<ApiResponse<dynamic>> GetById(int id);
        Task<ApiResponse<string>> Delete(int id);
    }
}
