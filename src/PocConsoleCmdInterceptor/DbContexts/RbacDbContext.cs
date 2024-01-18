using Microsoft.EntityFrameworkCore;

namespace PocConsoleCmdInterceptor.DbContexts
{
    public class RbacDbContext : BaseDbContext
    {
       public DbSet<Order> Orders { get; set; }
    }
}