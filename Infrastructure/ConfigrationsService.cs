using Attendleave.Erp.Core.APIUtilities;
using Attendleave.Erp.Core.Repository;
using Attendleave.Erp.Core.UnitOfWork;
using DataLayer.Identity;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingProgram.Infrastructure
{
    public static class ConfigrationsService
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext, MyDBContext>();
            services.AddTransient<IActionResultResponseHandler, ActionResultResponseHandler>();
            services.AddTransient<IRepositoryActionResult, RepositoryActionResult>();
            services.AddTransient<IRepositoryResult, RepositoryResult>();
            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddScoped<IUnitOfWork<ApplicationUser>, UnitOfWork<ApplicationUser>>();
            services.AddScoped<IRepository<ApplicationRole>, Repository<ApplicationRole>>();
            services.AddScoped<IUnitOfWork<ApplicationRole>, UnitOfWork<ApplicationRole>>();

            services.AddScoped<IRepository<Employee>, Repository<Employee>>();
            services.AddScoped<IUnitOfWork<Employee>, UnitOfWork<Employee>>();
            return services;
        }
    }
}
