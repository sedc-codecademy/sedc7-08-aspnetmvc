using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workshop.PizzaApp.Data;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Data.Repositories;
using Workshop.PizzaApp.Service.Interfaces;
using Workshop.PizzaApp.Service.Services;

namespace Workshop.PizzaApp.App
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IPizzaManagementService, PizzaManagementService>();
            services.AddScoped<ISizeManagementService, SizeManagementService>();
            services.AddScoped<IPizzaSizeManagementService, PizzaSizeManagementService>();

            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IPizzaSizeRepository, PizzaSizeRepository>();

            services.AddDbContext<PizzaAppDbContext>();
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
