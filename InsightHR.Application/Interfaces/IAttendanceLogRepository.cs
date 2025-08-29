using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IAttendanceLogRepository
    {

        Task<IEnumerable<dynamic>> GetAll();
        Task<int> Insert(AttendanceLogDto log);
        Task<int> Update(AttendanceLogUpdateDto log);
        Task<int> Delete(int id);
    }
}
