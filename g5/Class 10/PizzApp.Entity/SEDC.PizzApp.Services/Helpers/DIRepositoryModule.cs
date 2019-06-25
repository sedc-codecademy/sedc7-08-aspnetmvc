using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzApp.DataAccess;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.DataAccess.Repositories.CacheRepositories;
using SEDC.PizzApp.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.PizzApp.DataAccess.Repositories.EntityRepositories;

namespace SEDC.PizzApp.Services.Helpers
{
    public static class DIRepositoryModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddDbContext<PizzaDbContext>(x =>
            x.UseSqlServer("Server=.\\SQLExpress;Database=PizzaDb;Trusted_Connection=True")
            );
            services.AddTransient<IRepository<User>, UserEntityRepository>();
            services.AddTransient<IRepository<Order>, OrderEntityRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaEntityRepository>();
            services.AddTransient<IRepository<Feedback>, FeedbackEntityRepository>();
            return services;
        }
    }
}
