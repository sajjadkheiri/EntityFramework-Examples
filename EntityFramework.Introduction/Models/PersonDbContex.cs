using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Introduction;

public class PersonDbContex : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial catalog=EFTest;User Id=sa;Password=Str0ngPa$$w0rd;TrustServerCertificate=True");
    }
}
