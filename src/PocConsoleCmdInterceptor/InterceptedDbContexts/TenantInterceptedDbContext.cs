using Microsoft.EntityFrameworkCore;
using PocConsoleCmdInterceptor.CommandInterceptors;
using PocConsoleCmdInterceptor.DbContexts;

namespace PocConsoleCmdInterceptor.ContextInterceptors
{
    // RegisterStatelessInterceptor
    public class TenantInterceptedDbContext : TenantDbContext
    {
        private static readonly TenantFilterCommandInterceptor _interceptor
            = new TenantFilterCommandInterceptor();

        //public TenantInterceptedDbContext()
        //{
        //}
        //public TenantInterceptedDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.AddInterceptors(_interceptor);
    }
}