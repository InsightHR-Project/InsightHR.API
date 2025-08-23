using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<dynamic>> GetAllAsync();
        Task<int> CreateAsync(JobCreateDto jobDto);
        Task<int> UpdateAsync(JobUpdateDto jobDto);
        Task<int> DeleteAsync(int id);
    }
}
