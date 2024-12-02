using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("int");

        builder.Property(u => u.Title).IsRequired().HasMaxLength(250);
        builder.Property(u => u.Price).IsRequired();

    }
}
