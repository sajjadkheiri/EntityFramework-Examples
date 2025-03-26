using EF.Relationship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.Relationship.Infrastructure.Repository;

public class RelationshipDbContext(DbContextOptions<RelationshipDbContext> option) : DbContext(option)
{
    public DbSet<Person> People { get; set; }
}