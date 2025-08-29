using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<dynamic> GetById(int userId);
        Task<int> Delete(int userId);
        Task<int> ChangeRole(int userId, int newRoleId);
    }
}
