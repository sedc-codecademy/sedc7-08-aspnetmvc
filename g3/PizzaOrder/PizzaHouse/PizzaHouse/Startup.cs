﻿using BusinessLayer;
using DataLayer;
using DtoModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaHouse
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                });

            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPizzaIngredientRepository, PizzaIngredientRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddMvc();

            const string connection = @"Server=.;Database=PizzaRestaurant;Trusted_Connection=True";
            services.AddDbContext<PizzaSystemDbContext>
                (options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
