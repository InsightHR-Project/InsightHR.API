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
    public class UserService : IUserService
    {
        private readonly IUserRepository _adminRepository;

        public UserService(IUserRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
        {
            var users = await _adminRepository.GetAll();
            return ApiResponse<IEnumerable<dynamic>>.Ok(users, "Users retrieved successfully.");
        }

        public async Task<ApiResponse<dynamic>> GetById(int id)
        {
            var user = await _adminRepository.GetById(id);
            if (user == null)
                return ApiResponse<dynamic>.Fail("User not found.", 404);

            return ApiResponse<dynamic>.Ok(user, "User retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Delete(int id)
        {
            await _adminRepository.Delete(id);
            return ApiResponse<string>.Ok("User deleted successfully.");
        }

        public async Task<ApiResponse<string>> ChangeRole(int userId, int newRoleId)
        {
            await _adminRepository.ChangeRole(userId, newRoleId);
            return ApiResponse<string>.Ok("User role updated successfully.");
        }
    }
}
