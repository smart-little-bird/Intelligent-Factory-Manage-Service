using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ContractEntityTypeConfiguration: IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("contract", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(b => b.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.ClientName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.ClientId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
        
        builder.Property(b => b.Phone)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
        
        builder.Property(b => b.ContractNo)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder
            .OwnsOne(o => o.PaymentMethod, a =>
            {
                // a.HasIndex(t => t.Id); 
                // todo fix the problem
                a.Property(p => p.PaymentType).HasColumnName("PaymentType");
                a.Property(p => p.PayPercentJson).HasColumnName("PayPercent");
            });

        builder.HasMany(b => b.ContractContexts)
            .WithOne()
            .HasForeignKey(b => b.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}