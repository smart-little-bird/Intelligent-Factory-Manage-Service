using Intelligent.Factory.Management.Domain.AggregatesModel.ContractAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Contract>
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

        builder.Property(b => b.ContractStatus)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder
            .OwnsOne(o => o.PaymentMethod, a =>
            {
                a.Property(p => p.PaymentType).HasColumnName("PaymentType");
                a.Property(p => p.PayPercentJson).HasColumnName("PayPercent");
            });

        builder
            .OwnsOne(o => o.LogisticsInfo, a =>
            {
                a.Property(p => p.ShipDateTime).HasColumnName("ShipDateTime");
                a.Property(p => p.ShipType).HasColumnName("ShipType");
                a.Property(p => p.LogisticsUndertaker).HasColumnName("LogisticsUndertaker");
            });

        builder
            .OwnsOne(o => o.FaxInfo, a =>
            {
                a.Property(p => p.IsCombineFax).HasColumnName("IsCombineFax");
                a.Property(p => p.TaxRate).HasColumnName("TaxRate");
            });

        builder.HasMany(b => b.ContractContexts)
            .WithOne()
            .HasForeignKey(b => b.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}