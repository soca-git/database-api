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
            services.AddDbContext<DataContext>(options => options.UseNpgsql(GetConnectionString(configuration, environment)));

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
            var databaseUri = new Uri("postgres://nqhthbhzbmxzfj:8b586ae4f91f42be36d6924927c8a6566633dd057312fe4adddb6ea4517053ec@ec2-99-81-137-11.eu-west-1.compute.amazonaws.com:5432/dc78m9qca8qikv");
            string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);
            
            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseUri.LocalPath.TrimStart('/')};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
    }
}
