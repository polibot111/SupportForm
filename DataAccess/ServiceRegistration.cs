using DataAccess.Abstracts.Repositories.Endpoint;
using DataAccess.Abstracts.Repositories.FormStatus;
using DataAccess.Abstracts.Repositories.SupportForm;
using DataAccess.Abstracts.Services;
using DataAccess.Contexts;
using DataAccess.Mapper;
using DataAccess.Repositories.Endpoint;
using DataAccess.Repositories.FormStatus;
using DataAccess.Repositories.SupportForm;
using DataAccess.Services;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);


            #region Repositories
            services.AddScoped<IEndpointReadRepo, EndpointReadRepo>();
            services.AddScoped<IEndpointWriteRepo, EndpointWriteRepo>();
            services.AddScoped<IFormStatusReadRepo, FormStatusReadRepo>();
            services.AddScoped<IFormStatusWriteRepo, FormStatusWriteRepo>();
            services.AddScoped<ISupportFormReadRepo, SupportFormReadRepo>();
            services.AddScoped<ISupportFormWriteRepo, SupportFormWriteRepo>();

            #endregion

            #region 
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISupportFormService, SupportFormService>();
            services.AddScoped<IFormStatusService, FormStatusService>();
            #endregion
        }
    }
}
