using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PocConsoleCmdInterceptor.ContextInterceptors;
using PocConsoleCmdInterceptor.DbContexts;

namespace PocConsoleCmdInterceptor;

public class Program
{
    //private static Action<SqlServerDbContextOptionsBuilder>? _connectionString;

    public static void Main()
    {
        // unit of data segregation or isolation
        // - tenant
        // - role
        // - user

        //SeedDb();


        // retrieve by tenant id
        using (var context = new TenantDbContext())
        {

            var ordersT1 = context.Orders.TagWith("tenantId:1").ToList();
            Debug.Assert(ordersT1.Count == 4);

            var ordersT2 = context.Orders.TagWith("tenantId:2").ToList();
            Debug.Assert(ordersT2.Count == 3);

            var ordersT3 = context.Orders.ToList();

            // Q: Why does this fail?
            Debug.Assert(ordersT3.Count == 1);
        }

        //// retrieve by tenant id
        //using (var context = new RbacFilterContextInterceptor())
        //{

        //    var ordersT1 = context.Orders.TagWith("tenantId:1").ToList();
        //    Debug.Assert(ordersT1.Count == 3);

        //    var ordersT2 = context.Orders.TagWith("tenantId:2").ToList();
        //    Debug.Assert(ordersT2.Count == 2);

        //    var ordersT3 = context.Orders.ToList();

        //    // Q: Why does this fail?
        //    Debug.Assert(ordersT3.Count == 1);
        //}
    }

    private static void SeedDb()
    {
        using (var context = new TenantDbContext())
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            context.AddRange(
                new User { Name = "Alice", Email = "alice@tenant1.com", Role = "Admin" },
                new User { Name = "Bob", Email = "bob@tenant1.com", Role = "User" },
                new User { Name = "Eve", Email = "eve@tenant2.com", Role = "Admin" },
                new User { Name = "Alice", Email = "alice@tenant1.com", Role = "User" },
                new User { Name = "Mallory", Email = "mallory@tenant3.com", Role = "Admin" }
            );
            context.SaveChanges();
        }

        //Create every time
        using (var context = new TenantInterceptedDbContext())
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            context.AddRange(
                new Order { OrderId = 1, TenantId = 1, UserId = 1 },
                new Order { OrderId = 2, TenantId = 1, UserId = 2 },
                new Order { OrderId = 3, TenantId = 1, UserId = 2 },
                new Order { OrderId = 4, TenantId = 1, UserId = 3 },
                new Order { OrderId = 21, TenantId = 2, UserId = 1 },
                new Order { OrderId = 22, TenantId = 2, UserId = 3 },
                new Order { OrderId = 22, TenantId = 2, UserId = 4 },
                new Order { OrderId = 33, TenantId = 3, UserId = 5 }
                );

            context.SaveChanges();
        }
    }
}