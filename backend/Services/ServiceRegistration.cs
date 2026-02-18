using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Services_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceRegistration
    {
        public static void Addserviceregistration( this IServiceCollection services)
        {
            _ = services.AddScoped<ITaskServices, TaskServices>()
                .AddScoped<IUserServices, UserServices>();
               
        }
    }
}
