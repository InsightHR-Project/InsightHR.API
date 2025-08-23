
using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<int> Insert(RoleDto role);
        Task<int> Update(RoleUpdateDto role);
        Task<dynamic> GetRole(int id);
        Task<int> Delete(int id);
    }
      
}
