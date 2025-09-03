using InsightHR.Application.Interfaces;
using InsightHR.Infrastructure.Services;
using InsightHR.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHR.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IAttendanceLogRepository, AttendanceLogRepository>();
            //services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();

            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();
            services.AddScoped<IwagesRepositery, WagesRepo>();   
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Services
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IAttendanceLogService, AttendanceLogService>();
            //services.AddScoped<IPerformanceReviewService, PerformanceReviewService>();

            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ISalaryComponentService, SalaryComponentService>();
            //services.AddScoped<IwagesServices, wages>();         
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>(); 

            return services;
        }
    }
}
