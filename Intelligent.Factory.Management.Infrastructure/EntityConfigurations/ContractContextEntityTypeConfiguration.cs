using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ContractContextEntityTypeConfiguration : IEntityTypeConfiguration<ContractContext>
{
    public void Configure(EntityTypeBuilder<ContractContext> builder)
    {
        builder.ToTable("contractContext", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(b => b.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.ProductName)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(b => b.Material)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(b => b.Unit)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(b => b.UnitPrice)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();


        builder.Property(b => b.Amount)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder
            .OwnsOne(o => o.ContractContextProperty,
                a =>
                {
                    // a.HasIndex(t => t.Id);
                    a.Property(p => p.ProductId).HasColumnName("ProductId");
                    a.Property(p => p.IsIndependent).HasColumnName("IsIndependent");
                });
    }
}