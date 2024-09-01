using EF.Entities;
using EF.Entity;
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
    public List<Course> GetCourseAndTeacherEager()
    {
        var result = _dbContext.Courses.Include(x => x.CourseTeachers.Select(y => y.Teacher))
                                       //.ThenInclude(x => x.Teacher)
                                       .ToList();

        return result;
    }

    public List<Course> GetCourseAndTeacherAndTagEager()
    {
        var result = _dbContext.Courses.Include(x => x.CourseTeachers).ThenInclude(x => x.Teacher)
                                       .Include(x => x.Tags)
                                       .ToList();

        return result;
    }

    /// <summary>
    /// Collection :  tracking and loading information for a collection
    /// Reference : tracking and loading information for a reference
    /// </summary>
    public List<Course> GetCourseAndTeacherExplicit()
    {
        var courses = _dbContext.Courses.ToList();

        foreach (var course in courses)
        {
            _dbContext.Entry(course).Collection(x => x.CourseTeachers).Load();

            foreach (var courseTeacher in course.CourseTeachers)
            {
                _dbContext.Entry(courseTeacher).Reference(x => x.Teacher).Load();
            }
        }

        return courses;
    }

    public List<CourseInfoOutputDto> GetCourseInfoSelect()
    {
        var course = _dbContext.Courses.Select(x => new CourseInfoOutputDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();

        return course;
    }

    /// <summary>
    ///It allows you to run code at the last stage of the query that can’t be converted to database commands
    ///Tip : If your LINQ queries can’t be converted to database commands, EF Core will throw an "InvalidOperationException", 
    ///with a message containing "the words could not be translated".
    /// </summary>
    public IQueryable<Course> GetCourseTagsClientVsServer()
    {
        var course = _dbContext.Courses.Include(x => x.Tags)
                                       .Select(x => new Course
                                       {
                                           Id = x.Id,
                                           Name = x.Name,
                                           Description = string.Join(',', x.Tags)
                                       });

        return course;
    }

    /// <summary>
    /// OrderBy / OrderByDesc / ThenBy / ThenByDesc
    /// You just can use OrderBy / OrderByDesc in the first stage, after that if you want to do filter again
    /// you must use ThenBy / ThenByDesc
    /// Tip : If you use OrderBy / OrderByDesc after first stage, all data was filterd will destroyed
    /// </summary>
    public void GetCourseSortedData()
    {
        var result = _dbContext.Tags.OrderBy(x => x.Name)
                                    .ToList();
    }

    public List<Course> FilterdCourseByLike()
    {
        var result = _dbContext.Courses.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.Like(x.Name, "a%"))
                                       .ToList();

        return result;
    }

    /// <summary>
    /// Take / Skip
    /// </summary>
    public List<Course> GetCourseWithPaging()
    {
        var result = _dbContext.Courses.Skip(2)
                                       .Take(5)
                                       .ToList();

        return result;
    }

    /// <summary>
    /// When an entity has relation to other entities, this help you to get
    /// dependent data.However, AsNoTracking has a great efficiency because
    /// doesn't get dependent data.
    /// </summary>
    public Comment GetCommentsByRelationalFixup(int courseId)
    {
        var result = _dbContext.Comments.Where(x => x.Course.Id == courseId)
                                  .SingleOrDefault();

        return result;
    }

    public Comment GetCommentsByAsNoTracking(int courseId)
    {
        var result = _dbContext.Comments.AsNoTracking()
                                        .Where(x => x.Course.Id == courseId)
                                        .SingleOrDefault();

        return result;
    }
}
