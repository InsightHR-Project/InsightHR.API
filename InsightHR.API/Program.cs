using InsightHR.API.Middleware;
using InsightHR.Application.Interfaces;
using InsightHR.Infrastructure.Services;
using InsightHR.Persistence.Context;
using InsightHR.Persistence.Repositories;
using InsightHR.Infrastructure.Extensions;

namespace InsightHR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Application Services & Repositories
            builder.Services.AddApplicationServices();

            builder.Services.AddScoped<IwagesRepositery, WagesRepo>();
            builder.Services.AddScoped<IwagesServices, Employee_Wages>();


            builder.Services.AddScoped<DapperContext>();

            var app = builder.Build();


            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            //app.UseMiddleware<ApiKeyMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
