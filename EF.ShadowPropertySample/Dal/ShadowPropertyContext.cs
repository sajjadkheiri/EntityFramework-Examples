using EF.ShadowPropertySample.Dal.Configurations;
using EF.ShadowPropertySample.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.ShadowPropertySample.Dal;

internal class ShadowPropertyContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial catalog=ShadowPropertySampleDb;User=sa;Password=1qaz@WSX");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Intial configuration peer assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfig).Assembly);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

        AddedEntities.ForEach(E =>
        {
            E.Property("CreatedDateTime").CurrentValue = DateTime.Now;
        });

        var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

        EditedEntities.ForEach(E =>
        {
            E.Property("EditDateTime").CurrentValue = DateTime.Now;
        });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
