using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductAppApi.Core;
using ProductAppApi.Persistance;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductAppApi
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

            ///<summary>
            ///this is where the product context is added taking it's values
            ///such as connection string and making it a singleton .. created once in the life time of the app
            ///</summary>
            services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ProductCon"))
            , ServiceLifetime.Singleton);



            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Product API",
                    Description = "A simple Product ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Omar M. Ayyad",
                        Email = "omarayyad36@gmail.com",
                        Url = "https://www.linkedin.com/in/omar-ayyad-b43455a5/"
                    }
                    
                });
            });
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
                app.UseHsts();
            }



            ///<summary>
            ///allowing any origin or method of header or credentials
            ///not a good thing security wise 
            ///it's done to make the front end a little bit easier
            /// </summary>
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            // Creates Swagger JSON
            //app.UseSwagger(c =>
            //{
            //    c.RouteTemplate = "api/docs/{documentName}";
            //});
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Api V1");
                c.RoutePrefix = string.Empty;
            });



        }



    }
}



//services.AddScoped<IUnitOfWork,UnitOfWork>();