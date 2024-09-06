using Microsoft.EntityFrameworkCore;

namespace EF.ConfigurationSample;

public class ConfigContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TypeAndNameWithDataAnnotation> typeAndNameWithDataAnnotations { get; set; }
    public DbSet<TypeAndNameWithFluentApi> typeAndNameWithFluentApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial catalog=ConfigSampleDb;User=sa;Password=1qaz@WSX");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ignore property
        modelBuilder.Entity<Person>().Ignore(x => x.Contacts);

        // Ignore class
        modelBuilder.Ignore<Contact>();

        // Intial configuration peer each config class
        modelBuilder.ApplyConfiguration(new PersonConfig());
        modelBuilder.ApplyConfiguration(new TypeAndNameConfig());

        // Intial configuration peer assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfig).Assembly);        
    }
}
