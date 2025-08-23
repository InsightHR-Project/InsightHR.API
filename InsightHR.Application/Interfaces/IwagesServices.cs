using InsightHR.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Application.Interfaces
{
    public interface IwagesServices
    {
        Task AddWages(WagesRequest request);
        Task<IEnumerable<WagesResponse>> Getwages();

        Task UpdateWages(UpdateWagesRequest request);

        Task<int> DeleteWages(DeleteWagesRequest deleteWages);

        Task<WagesResponse> GetwagesbyID(GetWagesByIdRequest getWagesById);
    }
    public interface IwagesRepositery
    {
        Task<int> AddWagesAsync(WagesRequest request);
        Task<IEnumerable<WagesResponse>> Getwages();

        Task<int> UpdateWagesAsync(UpdateWagesRequest request);

        Task<int> DeleteWages(DeleteWagesRequest deleteWages);

        Task<WagesResponse> GetwagesbyID(GetWagesByIdRequest getWagesById);
    }
}
