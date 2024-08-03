using Microsoft.EntityFrameworkCore;
using EntityFramework.Entities;

namespace EntityFramework.DataAccess;

public class CourseDbContext : DbContext
{
    public DbSet<EntityFramework.Entities.Class1> MyProperty { get; set; }
}
