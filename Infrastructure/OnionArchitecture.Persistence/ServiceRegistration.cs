using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstractions.Services;
using OnionArchitecture.Persistence.DbContexts;
using OnionArchitecture.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddDbContext<EventifyDbContext>();
        }
    }
}
