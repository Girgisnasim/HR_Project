
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HR_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var txt = "hi";
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<HRContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<Repositories.IAttend, Repositories.Attends>();
            builder.Services.AddScoped<Repositories.IDepartment, Repositories.Departments>();
            builder.Services.AddScoped<Repositories.IEmp_Holiday, Repositories.Emp_Holidays>();
            builder.Services.AddScoped<Repositories.IEmployee, Repositories.Employees>();
            builder.Services.AddScoped<Repositories.IGeneral_Rules, Repositories.Generals_Rules>();
            builder.Services.AddScoped<Repositories.IHoliday, Repositories.Holidays>();
            builder.Services.AddScoped<Repositories.IHR, Repositories.HRs>();
            builder.Services.AddScoped<Repositories.IPermissions_Department, Repositories.Permissions_Departments>();
            builder.Services.AddScoped<Repositories.Permissions_HRs, Repositories.Permissions_HRs>();






            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}
