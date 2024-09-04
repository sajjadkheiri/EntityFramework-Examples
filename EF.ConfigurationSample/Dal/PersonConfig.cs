using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.ConfigurationSample;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Ignore(x => x.Contacts);
        builder.Property(x => x.FirstName).HasMaxLength(50);
    }
}
