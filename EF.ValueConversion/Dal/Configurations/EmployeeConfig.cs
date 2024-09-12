using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.ValueConversion;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.EmployeeType).HasConversion<string>();
        builder.Property(x=>x.EmployeeType).HasConversion<EmployeeTypeEnumToStringConverter>();
        builder.Property(x => x.Age).HasConversion(e => e.ToString(), e => int.Parse(e));
    }
}
