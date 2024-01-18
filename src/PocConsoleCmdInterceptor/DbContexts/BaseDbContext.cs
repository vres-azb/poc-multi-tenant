using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PocConsoleCmdInterceptor.DbContexts
{
    public abstract class BaseDbContext : DbContext
    {
        // TODO: refactor this later
        private const string ConnectionStringSql = @"localhost";

        protected BaseDbContext() : base(
            new DbContextOptionsBuilder()
            .LogTo(Console.WriteLine, LogLevel.Information)
            .UseSqlServer(ConnectionStringSql)
            .Options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("poc_datasegregation");
        }
    }
}