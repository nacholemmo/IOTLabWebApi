using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IOTLabWebApi.Core;
using IOTLabWebApi.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace IOTLabWebApi
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
            services.AddScoped<IUserAppProfileRepository,UserAppProfileRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();       
 
            services.AddAutoMapper();

            services.AddDbContext<IotLabDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
                {
                    options.Authority = "https://userapps.auth0.com/";
                    options.Audience = "https://api.iotlab.com";
                });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials() );
            });

            services.AddMvc();

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "IOT Lab API",
                        Description = "API de la aplicacion iot lab",
                        TermsOfService = "None",
                        Contact = new Contact { Name = "Ignacio Lemmo", Email = "ignacio.lemmo@gmail.com"},
                        License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
                {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IOT Lab API V1");
            });    

            app.UseCors("CorsPolicy");      

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
