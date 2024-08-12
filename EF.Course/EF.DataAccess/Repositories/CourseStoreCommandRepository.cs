﻿using EF.Entities;

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
            Name = "",
            Price = ,
            DateTime = DateTime.Now,
            Description = "",
            Comments = new()
            {
                new Comment{
                    CommentText = "",
                    CommentBy = "",
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
}
