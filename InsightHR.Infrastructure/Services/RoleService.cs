using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using InsightHR.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

   
        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
        {
            var roles = await _roleRepository.GetAll();
            return ApiResponse<IEnumerable<dynamic>>.Ok(roles, "Roles retrieved successfully.");
        }

        public async Task<ApiResponse<string>> Create(RoleDto role)
        {
            await _roleRepository.Insert(role);
            return ApiResponse<string>.Ok("Role created successfully.", "The role was successfully added");
        }

       
        public async Task<ApiResponse<string>> Update(RoleUpdateDto role)
        {
            await _roleRepository.Update(role);
            return ApiResponse<string>.Ok("Role updated successfully.",
                "The role details have been successfully updated.");
        }


        public async Task<ApiResponse<dynamic>> GetById(int id)
        {
            var role = await _roleRepository.GetRole(id);
            if (role == null)
                return ApiResponse<dynamic>.Fail("Role not found.", 404);

            return ApiResponse<dynamic>.Ok(role, "Role retrieved successfully.");
        }

    
        public async Task<ApiResponse<string>> Delete(int id)
        {
            await _roleRepository.Delete(id);
            return ApiResponse<string>.Ok("Role deleted successfully.");
        }
    }
}
