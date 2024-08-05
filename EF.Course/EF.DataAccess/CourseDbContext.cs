using System.Data;
using Microsoft.EntityFrameworkCore;
using EF.Entities;

namespace EF.DataAccess;

public class CourseDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<CourseTeachers> CourseTeachers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
