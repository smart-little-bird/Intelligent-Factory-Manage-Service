using Intelligent.Factory.Management.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intelligent.Factory.Management.Infrastructure.EntityConfigurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee", IntelligentFactoryManagementContext.DEFAULT_SCHEMA);

        builder.HasKey(b => b.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.EmployeeName)
            .HasMaxLength(10)
            .IsRequired();
        
        builder.Property(b => b.EntryTime)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();
        
        builder
            .OwnsOne(o => o.BasicInfo, a =>
            {
                a.Property(p => p.Age).HasColumnName("Age");
                a.Property(p => p.Gender).HasColumnName("Gender");
                a.Property(p => p.Phone).HasColumnName("Phone");
                a.Property(p => p.IdCardNo).HasColumnName("IdCardNo");
            });

        builder
            .OwnsOne(o => o.WorkingInfo, a =>
            {
                a.Property(p => p.EmployeeType).HasColumnName("EmployeeType");
                a.Property(p => p.WorkingYear).HasColumnName("WorkingYear");
            });
    }
}