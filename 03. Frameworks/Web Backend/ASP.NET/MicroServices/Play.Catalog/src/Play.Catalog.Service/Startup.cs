using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Paly.Catalog.Service.Entities;
using Play.Catalog.Service.Settings;
using Play.Common.MongDB;
using Play.Common.Settings;

namespace Play.Catalog.Service
{
    public class Startup
    {
        private ServiceSettings serviceSettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            services.AddMongo()
                    .AddMongoRepository<Item>("items");

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, configurator) =>
                {
                    var rabbitMQSettings = Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
                    configurator.Host(rabbitMQSettings.Host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceSettings.ServiceName, false));
                });
            });

            //services.AddMassTransitHostedService(); // 최신버전의 Masstransit 에서는 호출할 필요 없음.

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Play.Catalog.Service", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Play.Catalog.Service v1"));
            }

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
