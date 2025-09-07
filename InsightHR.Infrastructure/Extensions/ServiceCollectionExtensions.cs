using Application.Common.Interfaces;
using InsightHR.Application.Interfaces;
using InsightHR.Infrastructure.Services;
using InsightHR.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsightHR.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Repositories
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IAttendanceLogRepository, AttendanceLogRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IwagesRepositery, WagesRepo>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Services
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IAttendanceLogService, AttendanceLogService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ISalaryComponentService, SalaryComponentService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IwagesServices, Employee_Wages>();

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IEmailService,MailtrapEmailService>();


            //// Email Service (SendGrid)
            //var apiKey = config["SendGrid:ApiKey"];
            //services.AddSingleton<IEmailService>(new SendGridEmailService(apiKey));

            return services;
        }
    }
}
