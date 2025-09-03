using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<int> CreateAsync(LeaveRequestCreateDto dto);
        Task<int> UpdateAsync(LeaveRequestUpdateDto dto);
        Task<int> DeleteAsync(int id);
        Task<int> ManagerDecisionAsync(ManagerDecisionDto dto);
    }
}
