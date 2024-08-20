using Microsoft.EntityFrameworkCore;

namespace EF.Introduction;

public class PersonDbContex : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial catalog=EFTest;User Id=sa;Password=1qaz@WSX;TrustServerCertificate=True");
    }
}
