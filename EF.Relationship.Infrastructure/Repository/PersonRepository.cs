using EF.Relationship.Domain.Model;

namespace EF.Relationship.Infrastructure.Repository;

public class PersonRepository
{
    private readonly RelationshipDbContext _context;

    public PersonRepository(RelationshipDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Person> GetAll()
    {
        return _context.People.ToList();
    }

    public async Task<int> Add(Person person)
    {
        _context.People.Add(person);
        
        await _context.SaveChangesAsync();
        
        return person.Id;
    }
}