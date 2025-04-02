using EF.Relationship.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EF.Relationship.Infrastructure.Repository;

public class RelationshipDbContext : DbContext
{
    public RelationshipDbContext(DbContextOptions<RelationshipDbContext> option) : base(option)
    {
    }
    public DbSet<Person> People { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
}