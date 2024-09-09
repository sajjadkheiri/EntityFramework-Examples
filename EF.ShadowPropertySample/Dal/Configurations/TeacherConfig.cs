using EF.ShadowPropertySample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.ShadowPropertySample.Dal.Configurations;

internal class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property<DateTime>("CreatedDateTime");
        builder.Property<DateTime>("EditDateTime");
    }
}
