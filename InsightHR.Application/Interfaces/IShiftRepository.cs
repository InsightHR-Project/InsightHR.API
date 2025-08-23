using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IShiftRepository
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<int> Insert(ShiftDto shift);
        Task<int> Update(int id, ShiftDto shift);
        Task<dynamic> GetShift(int id);
        Task<int> Delete(int id);
    }
}
