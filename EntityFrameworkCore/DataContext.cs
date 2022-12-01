using EntityFrameworkCore.Tables;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// When running "Add-Migration" for the first time:
        /// No database provider has been configured for this DbContext.
        /// A provider can be configured by overriding the 'DbContext.OnConfiguring' method
        /// or by using 'AddDbContext' on the application service provider.
        /// If 'AddDbContext' is used, then also ensure that your DbContext type accepts
        /// a DbContextOptions<TContext> object in its constructor
        /// and passes it to the base constructor for DbContext.
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}
