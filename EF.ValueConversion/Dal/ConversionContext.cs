using Microsoft.EntityFrameworkCore;

namespace EF.ValueConversion;

public class ConversionContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial catalog=ConversionDb;User=sa;Password=1qaz@WSX;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfig).Assembly);
    }


}
