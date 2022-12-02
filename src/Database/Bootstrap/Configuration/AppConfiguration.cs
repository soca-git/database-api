using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Database.Bootstrap.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public AppConfiguration(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public string GetDatabaseConnectionString()
        {
            if (_environment.IsDevelopment())
            {
                return _configuration.GetConnectionString("TestDatabase");
            }

            return GetHerokuConnectionString();
        }

        private string GetHerokuConnectionString()
        {
            string url = Environment.GetEnvironmentVariable("DATABASE_URL");
            var uri = new Uri(url);
            string[] userInfo = uri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={uri.Host};Port={uri.Port};Database={uri.LocalPath.TrimStart('/')};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
    }
}
