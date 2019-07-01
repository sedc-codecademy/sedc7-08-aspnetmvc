using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.DataAccess.Repositories.CacheRepositories;
using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzApp.Services.Helpers
{
    public static class DIRepositoryModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaRepository>();
            services.AddTransient<IRepository<Feedback>, FeedbackRepository>();
            return services;
        }
    }
}
