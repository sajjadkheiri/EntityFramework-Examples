using EF.ShadowPropertySample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.ShadowPropertySample.Dal.Configurations;

internal class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property<DateTime>("CreatedDateTime");
        builder.Property<DateTime>("EditDateTime");
    }
}
