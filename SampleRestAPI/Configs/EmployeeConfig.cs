using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleRestAPI.Entities;
using System.Reflection.Emit;
using System;

namespace SampleRestAPI.Config;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x=>x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Age)
             .IsRequired();
        builder.Property(p => p.Status).HasDefaultValue(false);
    }
}
