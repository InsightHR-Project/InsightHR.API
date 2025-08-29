using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<IEnumerable<dynamic>>> GetAll();
        Task<ApiResponse<dynamic>> GetById(int id);
        Task<ApiResponse<string>> Delete(int id);
        Task<ApiResponse<string>> ChangeRole(int adminId, int newRoleId);
    }
}
