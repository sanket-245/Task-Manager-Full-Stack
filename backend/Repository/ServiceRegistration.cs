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
        public static void AddRepositoryService(this IServiceCollection services)
        {

           _=services.AddScoped<ITaskRepository, TaskRepository>().
            AddScoped<IUserRepository, UserRepository>();

            
        }
    }
}
