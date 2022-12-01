using Database.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Database.Bootstrap.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(GetConnectionString(configuration, environment)));

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                return configuration.GetConnectionString("TestDatabase");
            }

            return GetHerokuConnectionString();
        }

        private static string GetHerokuConnectionString()
        {
            string url = Environment.GetEnvironmentVariable("DATABASE_URL");
            var uri = new Uri(url);
            string[] userInfo = uri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);
            
            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={uri.Host};Port={uri.Port};Database={uri.LocalPath.TrimStart('/')};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
    }
}
