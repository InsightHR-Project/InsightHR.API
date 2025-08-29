using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<int> Insert(DepartmentDto dept);
        Task<int> Update(int id, DepartmentDto dept);
        Task<dynamic> GetById(int id);
        Task<int> Delete(int id);
    }
}
