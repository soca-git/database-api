using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Database.Bootstrap.Extensions
{
    internal static class HostExtensions
    {
        /// <summary>
        /// Attempts to migrate the database.
        /// This is used so we don't have to do it from Heroku CLI,
        /// since we are deploying a container. Better to do it here on application start.
        /// </summary>
        /// <typeparam name="TDataContext"></typeparam>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost MigrateDatabase<TDataContext>(this IHost host)
            where TDataContext : DbContext
        {
            using (var scope = host.Services.CreateScope()) // learn what this scope is doing, something related to DI?
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dataContext = services.GetRequiredService<TDataContext>();
                    dataContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // TODO: it would be good to log something here...
                }
            }

            return host;
        }
    }
}
