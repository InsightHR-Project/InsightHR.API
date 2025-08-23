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

            // Services
            services.AddScoped<IRoleService, RoleService>();

            // Add other repositories/services here as needed

            return services;
        }
    }
}
