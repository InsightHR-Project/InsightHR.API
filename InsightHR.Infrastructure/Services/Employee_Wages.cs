using InsightHR.Application.Dtos;
using InsightHR.Application.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Infrastructure.Services
{
    public class Employee_Wages : IwagesServices
    {
        private readonly IwagesRepositery _wagesRepository;

        public Employee_Wages(IwagesRepositery wagesRepository)
        {
            _wagesRepository = wagesRepository;
        }

        public async Task AddWages(WagesRequest request)
        {
            try
            {
                var affectedRows = await _wagesRepository.AddWagesAsync(request);

                if (affectedRows == 0)
                    throw new ArgumentException("User ID does not exist or wages not added.");
            }
            catch (SqlException ex) when (ex.Number == 50000 && ex.Message.Contains("User ID does not exist"))
            {
                throw new ArgumentException("User ID does not exist.");
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Database error occurred.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unexpected error occurred.", ex);
            }
        }
        public async Task<IEnumerable<WagesResponse>> Getwages()
        {
            var wages = await _wagesRepository.Getwages();

            if (wages == null)
                return new List<WagesResponse>();

            return wages;
        }
        public async Task UpdateWages(UpdateWagesRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Id <= 0)
                throw new ArgumentException("Invalid WageId.", nameof(request.Id));

            if (request.EmployeeWages < 0)
                throw new ArgumentException("Wages must be >= 0.", nameof(request.EmployeeWages));

            var affected = await _wagesRepository.UpdateWagesAsync(request);

            if (affected == 0)
                throw new KeyNotFoundException($"No wage record found with Id = {request.Id}");
        }
        public async Task<int> DeleteWages(DeleteWagesRequest deleteWages)
        {
            if (deleteWages.Id <= 0)
            {
                throw new ArgumentException("WageId must be greater than zero.");
            }
            return await _wagesRepository.DeleteWages(deleteWages);
        }

        public async Task<WagesResponse> GetwagesbyID(GetWagesByIdRequest getWagesById)
        {

            if (getWagesById == null || getWagesById.Id <= 0)
                throw new ArgumentException("Valid Wage Id is required");

            var wage = await _wagesRepository.GetwagesbyID(getWagesById);

            return wage;
        }
    }
}
