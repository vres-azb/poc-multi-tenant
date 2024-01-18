using Microsoft.EntityFrameworkCore;
using PocConsoleCmdInterceptor.CommandInterceptors;
using PocConsoleCmdInterceptor.DbContexts;

namespace PocConsoleCmdInterceptor.ContextInterceptors
{
    public class RbacInterceptedDbContext : RbacDbContext
    {
        private static readonly RbacFilterCommandInterceptor _interceptor
            = new RbacFilterCommandInterceptor();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.AddInterceptors(_interceptor);
    }
}