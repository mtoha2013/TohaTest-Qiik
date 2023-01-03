using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Toha.QIiik.Web.Services;

namespace Toha.QIiik.Web
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
            services.AddControllers();

            services.RegisterServices(Configuration);


            services.AddSwaggerGen((opt) =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API | Toha-QIIK-API",
                    Version = "v1",
                    Description = "Used for Handle Toha Test Api from QIIK",
                    Contact = new OpenApiContact()
                    {
                        Name = "private.mymail.mth@gmail.com",
                        Url = new System.Uri("https://code.kalbe.co.id/asd/api/rofo"),
                    }
                });


                var filePath = Path.Combine(AppContext.BaseDirectory, "Toha.QIiik.Web.xml");
                filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                if (File.Exists(filePath))
                    opt.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger(c => c.SerializeAsV2 = true);
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "API | Toha-QIIK-API 1.0"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
