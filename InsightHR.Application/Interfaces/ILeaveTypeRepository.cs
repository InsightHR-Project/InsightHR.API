using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ILeaveTypeRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<int> CreateAsync(LeaveTypeCreateDto dto);
        Task<int> UpdateAsync(LeaveTypeUpdateDto dto);
        Task<int> DeleteAsync(int id);
    }
}
