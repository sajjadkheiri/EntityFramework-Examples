using Microsoft.EntityFrameworkCore;

namespace EF.Index;

public class IndexContext : DbContext
{
    public DbSet<DataAnnotationIndex> dataAnnotationIndices { get; set; }
    public DbSet<FluentApiIndex> fluentApiIndices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FluentApiIndex>().HasIndex(x => x.Name).IsUnique();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
