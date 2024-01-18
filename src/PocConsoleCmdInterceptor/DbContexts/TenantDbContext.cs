using Microsoft.EntityFrameworkCore;
using PocConsoleCmdInterceptor.CommandInterceptors;

namespace PocConsoleCmdInterceptor.DbContexts
{
    public class TenantDbContext : BaseDbContext
    {
        private static readonly TenantFilterCommandInterceptor _tenantFilterInterceptor
            = new TenantFilterCommandInterceptor();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.AddInterceptors(_tenantFilterInterceptor);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
    }
}