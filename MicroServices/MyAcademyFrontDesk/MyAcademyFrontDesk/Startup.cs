using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAcademyFrontDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk
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
            services.AddControllersWithViews();

            var api1url = Configuration["ApiAddresses:TrainerServiceAPI"];
            var api2url = Configuration["ApiAddresses:CohortServiceAPI"];
            var api3url = Configuration["ApiAddresses:TrainingServiceAPI"];
            var api4url = Configuration["ApiAddresses:UsersServiceAPI"];

            services.AddHttpClient("TrainerServiceAPI", setup => setup.BaseAddress = new Uri(api1url));
            services.AddHttpClient("CohortServiceAPI", setup => setup.BaseAddress = new Uri(api2url));
            services.AddHttpClient("TrainingServiceAPI", setup => setup.BaseAddress = new Uri(api3url));
            services.AddHttpClient("UsersServiceAPI", setup => setup.BaseAddress = new Uri(api4url));

            services.AddScoped(typeof(TrainerService));
            services.AddScoped(typeof(CohortService));
            services.AddScoped(typeof(TrainingService));
            services.AddScoped(typeof(UsersService));


          
            services.AddSession();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Login}/{id?}");
            });
        }
    }
}
