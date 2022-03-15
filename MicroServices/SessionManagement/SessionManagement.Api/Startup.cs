using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SessionManagement.Api.HostedServices;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using SessionManagement.Core.Services;
using SessionManagement.Infrastructure.Data;
using SessionManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionManagement.Api
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
            services.AddHostedService<TrainerEntityAddListenerService>();
            services.AddHostedService<CohortEntityAddListenerService>();

            services.AddCors();
            services.AddControllers();
           
            var Connection = Configuration.GetConnectionString("SessionManagementConnection");
            services.AddDbContext<SessionManagementContext>(setup => setup.UseSqlServer(Connection));
            services.AddScoped<IRepository<Cohort>, GenericRepository<Cohort>>();
            services.AddScoped<IRepository<Trainer>, GenericRepository<Trainer>>();
            services.AddScoped<IRepository<TrainingSession>, GenericRepository<TrainingSession>>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Session management service",
                Description = "Session management microservice for CTS Academy"
            }));

            
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Session management service"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(setup => setup.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
