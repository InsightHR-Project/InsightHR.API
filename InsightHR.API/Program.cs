using InsightHR.Application.Interfaces;
using InsightHR.Infrastructure.Services;
using InsightHR.Persistence.Context;
using InsightHR.Persistence.Repositories;

namespace InsightHR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IwagesRepositery, WagesRepo>();
            builder.Services.AddScoped<IwagesServices, Employee_Wages>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
