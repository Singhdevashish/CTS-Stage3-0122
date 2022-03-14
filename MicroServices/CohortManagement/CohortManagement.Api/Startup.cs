using CohortManagement.Core;
using CohortManagement.Core.Interfaces;
using CohortManagement.Core.Services;
using CohortManagement.Infrastructure.Data;
using CohortManagement.Infrastructure.Repositories;
using CohortManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using CohortManagement.Core.Events;
using CohortManagement.Core.Settings;

namespace CohortManagement.Api
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
            services.AddCors();
            services.AddControllers();
            var connectionstring = Configuration.GetConnectionString("CohortManagementConnection");
            services.AddDbContext<CohortManagementContext>(option => option.UseSqlServer(connectionstring));
            services.AddScoped<IRepository<Cohort>, GenericRepository<Cohort>>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title="Cohort Management API",
                Description="Cohort management service for CTS Academy"
            }));
            services.AddScoped<IEmailService, EmailService>();
            services.AddMediatR(typeof(BaseEvent));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Cohort Management API"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
