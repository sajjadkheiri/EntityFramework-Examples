using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccess;

public class CourseStoreRepository
{
    private readonly CourseDbContext _dbContext;

    public CourseStoreRepository(CourseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Tip : Eager loading in EF Core is similar to that in EF6.x, but EF6.x doesn’t have a ThenInclude method.
    /// As a result, the Include/ThenInclude code used in listing 2.4 would be written in EF6.x as below code
    /// </summary>
    public List<Course> GetCourseAndTeacher()
    {
        var result = _dbContext.Courses.Include(x => x.CourseTeachers.Select(y => y.Teacher))
                                       //.ThenInclude(x => x.Teacher)
                                       .ToList();

        return result;
    }

    public List<Course> GetCourseAndTeacherAndTag()
    {
        var result = _dbContext.Courses.Include(x => x.CourseTeachers).ThenInclude(x => x.Teacher)
                                       .Include(x => x.Tags)
                                       .ToList();

        return result;
    }
}
