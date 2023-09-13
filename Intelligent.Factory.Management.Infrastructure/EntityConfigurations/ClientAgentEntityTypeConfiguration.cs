using Intelligent.Factory.Management.Domain.AggregatesModel.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class ClientAgentEntityTypeConfiguration : IEntityTypeConfiguration<ClientAgent>
{
    public void Configure(EntityTypeBuilder<ClientAgent> builder)
    {
        builder.ToTable("clientAgent", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);
        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.DomainEvents);
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.PhoneNumber).IsRequired();

    }
}