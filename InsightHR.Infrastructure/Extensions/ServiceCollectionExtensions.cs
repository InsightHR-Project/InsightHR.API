using InsightHR.Application.Interfaces;
using InsightHR.Infrastructure.Services;
using InsightHR.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<IAttendanceLogRepository,AttendanceLogRepository>();
            //services.AddScoped<IPerformanceReviewRepository,PerformanceReviewRepository>();



            // Services
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IShiftService, ShiftService>();    
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IAttendanceLogService, AttendanceLogService>();
            //services.AddScoped<IPerformanceReviewService,PerformanceReviewService>();


            return services;
        }
    }
}
