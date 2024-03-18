
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HR_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<HRContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<Repositories.IAttend, Repositories.Attend>();
            builder.Services.AddScoped<Repositories.IDepartment, Repositories.Department>();
            builder.Services.AddScoped<Repositories.IEmp_Holiday, Repositories.Emp_Holiday>();
            builder.Services.AddScoped<Repositories.IEmployee, Repositories.Employee>();
            builder.Services.AddScoped<Repositories.IGeneral_Rules, Repositories.General_Rules>();
            builder.Services.AddScoped<Repositories.IHoliday, Repositories.Holiday>();
            builder.Services.AddScoped<Repositories.IHR, Repositories.HR>();
            builder.Services.AddScoped<Repositories.IPermissions_Department, Repositories.Permissions_Department>();
            builder.Services.AddScoped<Repositories.Permissions_HR, Repositories.Permissions_HR>();






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
