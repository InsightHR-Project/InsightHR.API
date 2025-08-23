
using InsightHR.Application.Dtos;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IRoleService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<string>> Create(RoleDto role);
        Task<ApiResponse<string>> Update(RoleUpdateDto role);
        Task<ApiResponse<dynamic>> GetById(int id);
        Task<ApiResponse<string>> Delete(int id);
    }
}
