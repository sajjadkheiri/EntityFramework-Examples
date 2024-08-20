using EF.Entities;
using EF.Entity;
using Microsoft.Identity.Client;

namespace EF.DataAccess;

public class CourseStoreCommandRepository
{
    private readonly CourseDbContext _dbContext;

    public CourseStoreCommandRepository(CourseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddTag(string name)
    {
        Tag tag = new()
        {
            Name = name
        };

        Console.WriteLine($"Tag state step 1 : {_dbContext.Entry(tag).State}");

        _dbContext.Add(tag);

        Console.WriteLine($"Tag state step 2 : {_dbContext.Entry(tag).State}");

        _dbContext.SaveChanges();

        Console.WriteLine($"Tag state step 3 : {_dbContext.Entry(tag).State}");
    }

    public void AddCourseWithComment()
    {
        Course course = new()
        {
            Name = "Docker course",
            Price = 1000000,
            DateTime = DateTime.Now,
            Description = "Full course",
            Comments = new List<Comment>()
            {
                new() {
                    CommentText = "This is perfect",
                    CommentBy = "s.kheiri",
                    IsApproved = true,
                    StarCount = 5
                }
            }
        };

        Console.WriteLine($"Course state step 1 : {_dbContext.Entry(course).State}");
        Console.WriteLine($"Comment state step 1 : {_dbContext.Entry(course.Comments).State}");

        _dbContext.Add(course);

        Console.WriteLine($"Course state step 2 : {_dbContext.Entry(course).State}");
        Console.WriteLine($"Comment state step 2 : {_dbContext.Entry(course.Comments).State}");

        _dbContext.SaveChanges();

        Console.WriteLine($"Course state step 3 : {_dbContext.Entry(course).State}");
        Console.WriteLine($"Comment state step 3 : {_dbContext.Entry(course.Comments).State}");
    }

    /// <summary>
    /// Connected Update
    /// </summary>
    public void UpdateTagConnected(int id, string newName)
    {
        var tag = _dbContext.Tags.Find(id) ?? throw new Exception("There is no tag");

        tag.Name = newName;

        _dbContext.SaveChanges();
    }

    public void UpdateTagDisconnected(int id, string newName)
    {
        Tag tag = new()
        {
            Id = id,
            Name = newName
        };

        _dbContext.Update(tag);

        var a = _dbContext.Tags.Find(id);

        _dbContext.SaveChanges(true);
    }

    public void SaveCourse(CourseInfoOutputDto dto)
    {
        var course = _dbContext.Courses.FirstOrDefault(c => c.Id == dto.Id);

        course.Description = dto.Description;
        course.Name = dto.Name;

        _dbContext.SaveChanges();
    }

    public CourseInfoOutputDto GetCourse(int id)
    {
        return _dbContext.Courses.Where(c => c.Id == id).Select(c => new CourseInfoOutputDto
        {
            Id = c.Id,
            Description = c.Description,
            Name = c.Name
        }).FirstOrDefault();
    }

    public string GetTagName(int tagId)
    {
        return _dbContext.Tags.FirstOrDefault(t => t.Id == tagId).Name;
    }
}