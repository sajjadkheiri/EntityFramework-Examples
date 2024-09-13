using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Naming;

public class NamingConfig : IEntityTypeConfiguration<Train>
{
    public void Configure(EntityTypeBuilder<Train> builder)
    {
        builder.ToTable("Tbl_Train", "EF2");
        builder.Property(x => x.Name).HasColumnName("Train_Name");
    }
}
