using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
