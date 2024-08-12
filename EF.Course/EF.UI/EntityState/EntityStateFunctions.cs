using EF.DataAccess;
using EF.Entities;

namespace EF.UI;

public class EntityStateFunctions
{
    private readonly CourseDbContext _dbContext;

    /// <summary>
    /// The State tells EF Core what to do with this instance when SaveChanges is called.
    /// </summary>
    public EntityStateFunctions(CourseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// The entity you provided isn’t tracked. SaveChanges doesn’t see it.
    /// </summary>
    public void PrintDetachedState()
    {
        Tag tag = new();

        var tagState = _dbContext.Entry(tag).State;

        Console.WriteLine($"Tag state is : {tagState}");
    }

    /// <summary>
    /// The entity needs to be created in the database. SaveChanges inserts it.
    /// </summary>
    public void PrintAddedState()
    {
        Tag tag = new();

        _dbContext.Add(tag);

        var tagState = _dbContext.Entry(tag).State;

        Console.WriteLine($"Tag state is : {tagState}");
    }

    /// <summary>
    /// The entity exists in the database but should be deleted. SaveChanges deletes it.
    /// </summary>
    public void PrintDeletedState()
    {
        Tag tag = new()
        {
            Id = 1
        };

        _dbContext.Remove(tag);

        var tagState = _dbContext.Entry(tag).State;

        Console.WriteLine($"Tag state is : {tagState}");
    }

    /// <summary>
    /// The entity exists in the database and has been modified on the client.SaveChanges updates it.
    /// </summary>
    public void PrintUpdatedState()
    {
        Tag tag = new()
        {
            Id = 1
        };

        _dbContext.Update(tag);

        var tagState = _dbContext.Entry(tag).State;

        Console.WriteLine($"Tag state is : {tagState}");
    }

    /// <summary>
    /// The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it.
    /// </summary>
    public void PrintUnchangedState()
    {
        Tag tag = _dbContext.Tags.FirstOrDefault(t => t.Id == 2);


        var tagState = _dbContext.Entry(tag).State;

        Console.WriteLine($"Tag state is : {tagState}");
    }
}
