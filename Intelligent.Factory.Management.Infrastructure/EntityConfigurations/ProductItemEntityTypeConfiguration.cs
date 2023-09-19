using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ProductItemEntityTypeConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.ToTable("productItem", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.DomainEvents);

        builder.Property(x => x.Name)
            .HasMaxLength(40)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.ProductType)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Specifications)
            .HasMaxLength(100)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.TechnicalRequirements)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Amount)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Material)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property<string>(x => x.Unit)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Remark)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.ProductId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}