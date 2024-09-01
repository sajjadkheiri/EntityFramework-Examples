using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.DataAccess;

public class CommentRepository
{
    private readonly CourseDbContext _dbContext;

    public CommentRepository(CourseDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
