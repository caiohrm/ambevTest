using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Sales> Sales { get; set; }

    public DbSet<SaleProduct> SaleProducts { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasSequence<int>("ProductSequence");
        //modelBuilder.HasSequence<int>("ProductSalesSequence");
        //modelBuilder.HasSequence<int>("SalesSequence");
        //modelBuilder.Entity<Product>().
        //    Property(o => o.Id).
        //    HasDefaultValueSql("NEXT VALUE FOR ProductSequence");

        //modelBuilder.Entity<SaleProduct>().
        //    Property(o => o.Id).
        //    HasDefaultValueSql("NEXT VALUE FOR ProductSalesSequence");

        //modelBuilder.Entity<Sales>().
        //    Property(o => o.Id).
        //    HasDefaultValueSql("NEXT VALUE FOR SalesSequence");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
               connectionString,
               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
        );

        return new DefaultContext(builder.Options);
    }
}