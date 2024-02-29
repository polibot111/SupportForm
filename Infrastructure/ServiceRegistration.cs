using Infrastructure.Abstracts;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginOperations,LoginOperations> ();
            services.AddScoped<IApplicationService, ApplicationService> ();
            services.AddScoped<ITokenHandler, TokenHandler> ();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService> ();
        }
    }
}
