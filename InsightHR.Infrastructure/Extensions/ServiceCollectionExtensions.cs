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
            services.AddScoped<IChatRepository, ChatRepository>();

            services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();
            services.AddScoped<IwagesRepositery, WagesRepo>();
            services.AddScoped<ILoanRepository, LoanRepository>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();


            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IChatService, ChatService>();


            services.AddScoped<ISalaryComponentService, SalaryComponentService>();
            services.AddScoped<IwagesServices, Employee_Wages>();
            services.AddScoped<ILoanService,LoanService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped < IDepartmentService,DepartmentService > ();



            return services;
        }
    }
}
