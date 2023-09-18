using Intelligent.Factory.Management.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(o => o.Id);

        builder.Ignore(b => b.DomainEvents);

        builder
            .Property<string>(x => x.Description)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder
            .Property<string>(x => x.EntryCriteria)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.HasMany(b => b.ProductItems)
            .WithOne()
            .HasForeignKey(b => b.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}