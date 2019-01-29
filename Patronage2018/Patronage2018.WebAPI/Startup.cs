using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Patronage2018.Application.FizzBuzz.Queries;
using Patronage2018.Application.Infrastructure.AutoMapper;
using Patronage2018.Application.Interfaces;
using Patronage2018.Application.Notifications;
using Patronage2018.Application.Notifications.Models;
using Patronage2018.Application.Rooms.Commands.CreateRoom;
using Patronage2018.Infrastructure;
using Patronage2018.Persistence;
using Patronage2018.WebAPI.Middleware;
using System;
using System.IO;
using System.Reflection;

namespace Patronage2018.WebAPI
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
            services.Configure<MailSettings>(options => Configuration.GetSection("MailSettings").Bind(options));

            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).Assembly });

            services.AddMediatR(typeof(GetFizzBuzzQueryHandler).GetTypeInfo().Assembly);
            
            services.AddTransient<INotificationService, NotificationService>();

            services.AddDbContext<PatronageDbContext>(options =>
                options.UseSqlServer(Configuration.GetSection("ConnectionStrings").GetValue<string>("PatronageDatabase")));

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(option =>
            {
                option.DescribeAllEnumsAsStrings();
                option.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "REST API",
                    Version = "v1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                option.IncludeXmlComments(xmlPath);
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(settings =>
            {
                settings.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API");
                settings.RoutePrefix = string.Empty;

            });
        }
    }
}
