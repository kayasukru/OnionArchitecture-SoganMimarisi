using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstractions.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ExportService>();
        }
    }
}
