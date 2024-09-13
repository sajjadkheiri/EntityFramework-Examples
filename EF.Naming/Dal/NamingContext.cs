using Microsoft.EntityFrameworkCore;

namespace EF.Naming;

public class NamingContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial catalog=ConversionDb;User=sa;Password=1qaz@WSX;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add new default schema
        modelBuilder.HasDefaultSchema("EF2");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NamingConfig).Assembly);
    }
}
