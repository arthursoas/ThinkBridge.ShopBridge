using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ThinkBridge.ShopBridge.Data;
using ThinkBridge.ShopBridge.Data.Repositiories;
using ThinkBridge.ShopBridge.WebAPI.Configuration;
using ThinkBridge.ShopBridge.WebAPI.Settings;

namespace ThinkBridge.ShopBridge.WebAPI
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var domainSettings = Configuration.GetSection(nameof(DomainSettings)).Get<DomainSettings>();

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddCors(options =>
            {
                options.AddPolicy("All", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerConfig();
            services.AddDbContext<ShopBridgeDbContext>(options =>
                options.UseSqlServer(domainSettings.DatabaseSettings.ConnectionString));
            services.AddDataRepositories();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfig();
            app.UseRouting();
            app.UseCors("All");
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

