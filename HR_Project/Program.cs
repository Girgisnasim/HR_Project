
using HR_Project.Models;
using HR_Project.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


using static System.Net.Mime.MediaTypeNames;


using System.Security.Principal;
using System.Text;


namespace HR_Project
{
    public class Program
    {
        //public static object Configuration { get; private set; }


        public static void Main(string[] args)
        {
            var txt = "hi";
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<HRContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
           

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<HRContext>();
            // used jwt token in check authentiacation 
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudiance"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

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

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This�is�to�generate�the�Default�UI�of�Swagger�Documentation����
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET�5�Web�API",
                    Description = " ITI Projrcy"
                });

                //�To�Enable�authorization�using�Swagger�(JWT)����
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter�'Bearer'�[space]�and�then�your�valid�token�in�the�text�input�below.\r\n\r\nExample:�\"Bearer�eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                });
            });


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
            app.UseAuthentication();// check Jwt token 

            app.UseAuthorization();
            app.UseCors(txt);

            app.MapControllers();

            app.Run();
        }
    }
}
