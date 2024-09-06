using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.ConfigurationSample;

public class TypeAndNameConfig : IEntityTypeConfiguration<TypeAndNameWithFluentApi>
{
    public void Configure(EntityTypeBuilder<TypeAndNameWithFluentApi> builder)
    {
        builder.Property(x => x.Name).IsUnicode(false).IsRequired();
        builder.Property(x => x.Price).HasPrecision(14, 4);
        builder.Property(x => x.Code).IsUnicode(false).HasMaxLength(10);
    }
}
