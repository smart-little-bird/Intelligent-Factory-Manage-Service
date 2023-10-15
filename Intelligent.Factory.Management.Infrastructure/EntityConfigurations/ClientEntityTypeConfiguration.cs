using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("client", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(b => b.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.ClientType).IsRequired();

        //builder.HasOne(b => b.ClientAgent)
        //    .WithMany()
        //    .HasForeignKey("ClientAgentId")
        //    .OnDelete(DeleteBehavior.Cascade);

        builder
        .OwnsOne(o => o.ClientAgent, a =>
        {
            a.Property(p => p.Name).HasColumnName("ClientAgentName");
            a.Property(p => p.PhoneNumber).HasColumnName("ClientAgentPhoneNumber");
        });

        builder
            .OwnsOne(o => o.Address, a =>
            {
                a.Property(p => p.Street).HasColumnName("Street");
                a.Property(p => p.ZipCode).HasColumnName("ZipCode");
                a.Property(p => p.Province).HasColumnName("Province");
                a.Property(p => p.City).HasColumnName("City");
            });

        builder
            .OwnsOne(o => o.Bank, a =>
            {
                a.Property(p => p.BankTitle).HasColumnName("BankTitle");
                a.Property(p => p.BankAccount).HasColumnName("BankAccount");
            });

        builder.Property(b => b.BillingTelephone)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.TFN)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.ContactNumber)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Email)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();

        builder.Property(x => x.Fax)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}