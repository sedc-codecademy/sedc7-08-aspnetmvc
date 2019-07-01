using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaHut.BusinessLayer.Interfaces;
using SEDC.PizzaHut.BusinessLayer.Services;
using SEDC.PizzaHut.DataLayer;
using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.DataLayer.Repositories;
using SEDC.PizzaHut.WebApp.Filters;

namespace SEDC.PizzaHut.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            // Dependency Injection
            services.AddDbContext<PizzaHutContext>(opt => 
            opt
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("PizzaDbConnection"))
                );

            // Register Repositories
            services.AddScoped<IPizzaRepository, PizzaRepository>()
                .AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();

            // Register Services
            services.AddScoped<IPizzaService, PizzaService>()
                .AddScoped<IPizzaTypeService, PizzaTypeService>();


            services.AddMvc(
                config =>
                {
                    config.Filters.Add(new ValidationFilter());
                }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ValidationFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
