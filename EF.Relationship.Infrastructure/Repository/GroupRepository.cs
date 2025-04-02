using EF.Relationship.Domain.Model;

namespace EF.Relationship.Infrastructure.Repository;

public class GroupRepository
{
    private readonly RelationshipDbContext _context;

    public GroupRepository(RelationshipDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Group> GetAll()
    {
        return _context.Groups.ToList();
    }

    public Group GetById(int id)
    {
        return _context.Groups.Find(id) ?? throw new NullReferenceException("Group not found");
    }

    public async Task<int> Add(Group group)
    {
        _context.Groups.Add(group);
        
        await _context.SaveChangesAsync();
        
        return group.Id;
    }
}