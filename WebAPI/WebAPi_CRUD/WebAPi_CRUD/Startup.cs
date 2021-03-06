using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPi_CRUD.Models;

namespace WebAPi_CRUD
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
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddDbContext<ADM21DF014MVCCRUDContext>(setup =>
                    setup.UseSqlServer(Configuration.GetConnectionString("constr")));
            services.AddScoped<IRepository<Products>, GenereicRepository<Products>>();
            services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Products API",
                Description = "Allows CRUD operation on products table",
                Contact = new OpenApiContact
                {
                    Email = "Techiesyed@outlook.com",
                    Name = "Khaleelullah"
                }
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup => setup.SwaggerEndpoint("/swagger/v1/swagger.json","My APi"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(setup => 
                setup.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                //setup.WithOrigins("http://abc.com", "http://google.com")
                //     .WithMethods("GET","POST")
                //     .WithHeaders("Accept","Content-Type"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
