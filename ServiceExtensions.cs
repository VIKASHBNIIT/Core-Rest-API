using AutoMapper;
using Employee.Service;
using Employee.Service.Interface.Repository;
using Employee.Service.Interface.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork;

namespace Employee.API.ServiceExtension
{
    public static class ServiceExtensions
    {
       /// <summary>
       /// Register dependency injections
       /// </summary>
       /// <param name="services"></param>
       /// <param name="configuration"></param>
        public static void RegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<DbContext>(configuration.GetSection("ConnectionStrings"));
            services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
