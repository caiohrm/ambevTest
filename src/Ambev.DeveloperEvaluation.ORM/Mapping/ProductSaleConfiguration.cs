using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductSaleConfiguration : IEntityTypeConfiguration<SaleProduct>
{
    public void Configure(EntityTypeBuilder<SaleProduct> builder)
    {
        builder.ToTable("SaleProducts");

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("int");

        builder.Property(u => u.SalesId).IsRequired();
        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.UnitPrice).IsRequired();
        builder.Property(u => u.Total).IsRequired();

    }
}
