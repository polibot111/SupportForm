using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataCreator
{
    public static class ServiceRegistration
    {
        public static void AddDummyDataCreatorServices(this IServiceCollection services)
        {
            services.AddScoped<DummyDataCreater>();
        }
    }
}
