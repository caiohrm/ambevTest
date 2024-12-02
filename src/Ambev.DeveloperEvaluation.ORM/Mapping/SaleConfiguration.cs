using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sales>
{
    public void Configure(EntityTypeBuilder<Sales> builder)
    {
        builder.ToTable("Sales");

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        builder.HasMany(x => x.Product)
            .WithOne()
            .HasForeignKey(x=>x.SalesId);

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("int").UseSequence();

        builder.Property(u => u.CustomerId).IsRequired();
        builder.Property(u => u.Total).IsRequired();
        builder.Property(u => u.Branch).IsRequired();
        builder.Property(u => u.Canceled).IsRequired().HasDefaultValue(false);

    }
}
