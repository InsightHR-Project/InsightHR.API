//using InsightHR.Application.Dtos;
//using InsightHR.Application.Interfaces;
//using InsightHR.Persistence.Repositories;
//using InsightHR.Shared.Results;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InsightHR.Infrastructure.Services
//{
//    public class ApplicationService : IApplicationService
//    {

//        private readonly ApplicationRepository _repository;

//        public ApplicationService(ApplicationRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<ApiResponse<IEnumerable<dynamic>>> GetAll()
//        {
//            var data = await _repository.GetAll();
//            return ApiResponse<IEnumerable<dynamic>>.Ok(data, "Applications fetched");
//        }

//        public async Task<ApiResponse<string>> Create(ApplicationDto dto)
//        {
//            var result = await _repository.Insert(dto);
//            return result > 0
//                ? ApiResponse<string>.Ok("Application created successfully")
//                : ApiResponse<string>.Fail("Failed to create application");
//        }

//        public async Task<ApiResponse<string>> Update(ApplicationUpdateDto dto)
//        {
//            var result = await _repository.Update(dto);
//            return result > 0
//                ? ApiResponse<string>.Ok("Application updated successfully")
//                : ApiResponse<string>.Fail("Failed to update application");
//        }

//        public async Task<ApiResponse<string>> Delete(int id)
//        {
//            var result = await _repository.Delete(id);
//            return result > 0
//                ? ApiResponse<string>.Ok("Application deleted successfully")
//                : ApiResponse<string>.Fail("Failed to delete application");
//        }

//        public async Task<ApiResponse<string>> ScheduleInterview(ScheduleInterviewDto dto)
//        {
//            var result = await _repository.ScheduleInterview(dto);
//            return result > 0
//                ? ApiResponse<string>.Ok("Interview scheduled successfully")
//                : ApiResponse<string>.Fail("Failed to schedule interview");
//        }

//        public async Task<ApiResponse<string>> FinalSelection(FinalSelectionDto dto)
//        {
//            var result = await _repository.FinalSelection(dto);
//            return result > 0
//                ? ApiResponse<string>.Ok("Final decision updated successfully")
//                : ApiResponse<string>.Fail("Failed to update decision");
//        }

//    }
//}
